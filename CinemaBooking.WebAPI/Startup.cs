using CinemaBooking.Data;
using CinemaBooking.Domain.Interfaces;
using CinemaBooking.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace CinemaBooking.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = "https://localhost:4001";
                        options.RequireHttpsMetadata = true;
                        options.ApiName = "CinemaBookingAPI";
                    });

            services.AddDbContext<CinemaDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CinemaBookingDb"));
            });

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();

            services.AddAutoMapper(typeof(MapperProfiles));

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
        }
    }
}