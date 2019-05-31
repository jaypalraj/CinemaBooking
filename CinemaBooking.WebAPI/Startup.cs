using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.Domain.Interfaces;
using CinemaBooking.Infrastructure;
using CinemaBooking.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace CinemaBooking.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = CinemaBookingConstants.IdSrvUrl;
                        options.RequireHttpsMetadata = true;
                        options.ApiName = "CinemaBookingAPI";
                    });

            services.AddDbContext<CinemaDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CinemaBookingDb"));
            });

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IScreenRepository, ScreenRepository>();

            services.AddAutoMapper(typeof(MapperProfiles));

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Cinema Booking API", Version = "v1" });

                options.OperationFilter<CheckAuthorizeOptionsFilter>();

                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = $"{CinemaBookingConstants.IdSrvUrl}connect/authorize",
                    TokenUrl = $"{CinemaBookingConstants.IdSrvUrl}connect/token",
                    Scopes = new Dictionary<string, string>()
                    {
                        { "CinemaBookingAPI", "Cinema Booking API" }
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema Booking API V1");
                options.OAuthClientId("swagger.api.ui");
                options.OAuthAppName("Swagger API UI");
            });
        }
    }

    internal class CheckAuthorizeOptionsFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var authorizeAttributeExits = context.ApiDescription.ControllerAttributes().OfType<AuthorizeAttribute>().Any()
                                          || context.ApiDescription.ActionAttributes().OfType<AuthorizeAttribute>().Any();

            if (authorizeAttributeExits)
            {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });
                operation.Responses.Add("403", new Response { Description = "Forbidden" });

                operation.Security = new List<IDictionary<string, IEnumerable<string>>>();
                operation.Security.Add(new Dictionary<string, IEnumerable<string>>
                {
                    { "oauth2", new [] {"cinemaBookingApi"} }
                });
            }
        }
    }
}