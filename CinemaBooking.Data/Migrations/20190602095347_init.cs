using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBooking.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Ratings = table.Column<decimal>(nullable: false),
                    TrailerUrl = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    ScreenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.ScreenId);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ScreenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "ScreenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowTimes",
                columns: table => new
                {
                    ShowTimeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowDateTime = table.Column<DateTime>(nullable: false),
                    ScreenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTimes", x => x.ShowTimeId);
                    table.ForeignKey(
                        name: "FK_ShowTimes_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "ScreenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    SeatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieShowTime",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ShowTimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShowTime", x => new { x.MovieId, x.ShowTimeId });
                    table.ForeignKey(
                        name: "FK_MovieShowTime_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieShowTime_ShowTimes_ShowTimeId",
                        column: x => x.ShowTimeId,
                        principalTable: "ShowTimes",
                        principalColumn: "ShowTimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Title" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Horror" },
                    { 3, "Crime" },
                    { 4, "Drama" },
                    { 5, "Comedy" },
                    { 6, "Adventure" },
                    { 7, "Fantacy" },
                    { 8, "Romance" },
                    { 9, "Sci-Fi" },
                    { 10, "Mystrey" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Description", "IsActive", "Ratings", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 8, "A group of friends whose leisurely Mexican holiday takes a turn for the worse when they, along with a fellow tourist, embark on a remote archaeological dig in the jungle where something evil lives among the ruins.", true, 5.9m, "The Ruins", "https://www.youtube.com/watch?v=xVlBRkigRvc" },
                    { 7, "Four teenage boys enter a pact to lose their virginity by prom night.", true, 7m, "American Pie", "https://www.youtube.com/watch?v=iUZ3Yxok6N8" },
                    { 6, "A young woman suffering from Parkinson's befriends a drug rep working for Pfizer in 1990s Pittsburgh.", true, 6.7m, "Love & Other Drugs", "https://www.youtube.com/watch?v=h6w7Dh-QxzY" },
                    { 5, "Maxwell Smart, a highly intellectual but bumbling spy working for the CONTROL agency, is tasked with preventing a terrorist attack from rival spy agency KAOS.", true, 6.5m, "Get Smart", "https://www.youtube.com/watch?v=xbf9AWiJDBI" },
                    { 2, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", true, 8.8m, "Inception", "https://www.youtube.com/watch?v=YoHD9XEInc0" },
                    { 3, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", true, 9.3m, "The Shawshank Redemption", "https://www.youtube.com/watch?v=6hB3S9bIaco" },
                    { 1, "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.", true, 9m, "The Dark Knight", "https://www.youtube.com/watch?v=EXeTwQWrcwY" },
                    { 4, "After a tragic accident, two stage magicians engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.", true, 8.5m, "The Prestige", "https://www.youtube.com/watch?v=ijXruSzfGEc" }
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "ScreenId", "Title" },
                values: new object[,]
                {
                    { 4, "Screen4" },
                    { 1, "Screen1" },
                    { 2, "Screen2" },
                    { 3, "Screen3" },
                    { 5, "Screen5" }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "MovieId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 7, 5 },
                    { 6, 8 },
                    { 6, 4 },
                    { 6, 5 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 1 },
                    { 4, 10 },
                    { 8, 2 },
                    { 4, 4 },
                    { 3, 4 },
                    { 2, 9 },
                    { 2, 6 },
                    { 2, 1 },
                    { 1, 4 },
                    { 1, 3 },
                    { 4, 9 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "ScreenId", "Title" },
                values: new object[,]
                {
                    { 93, 4, "C3" },
                    { 94, 4, "C4" },
                    { 95, 4, "C5" },
                    { 96, 4, "C6" },
                    { 97, 4, "C7" },
                    { 98, 4, "C8" },
                    { 99, 4, "C9" },
                    { 100, 4, "C10" },
                    { 104, 4, "D4" },
                    { 102, 4, "D2" },
                    { 103, 4, "D3" },
                    { 105, 4, "D5" },
                    { 106, 4, "D6" },
                    { 107, 4, "D7" },
                    { 108, 4, "D8" },
                    { 92, 4, "C2" },
                    { 101, 4, "D1" },
                    { 91, 4, "C1" },
                    { 82, 4, "B2" },
                    { 89, 4, "B9" },
                    { 73, 4, "A3" },
                    { 74, 4, "A4" },
                    { 75, 4, "A5" },
                    { 76, 4, "A6" },
                    { 77, 4, "A7" },
                    { 78, 4, "A8" },
                    { 79, 4, "A9" },
                    { 90, 4, "B10" },
                    { 80, 4, "A10" },
                    { 109, 4, "D9" },
                    { 83, 4, "B3" },
                    { 84, 4, "B4" },
                    { 85, 4, "B5" },
                    { 86, 4, "B6" },
                    { 87, 4, "B7" },
                    { 88, 4, "B8" },
                    { 81, 4, "B1" },
                    { 110, 4, "D10" },
                    { 119, 4, "E9" },
                    { 112, 4, "E2" },
                    { 131, 5, "C1" },
                    { 132, 5, "C2" },
                    { 133, 5, "C3" },
                    { 134, 5, "C4" },
                    { 135, 5, "C5" },
                    { 136, 5, "C6" },
                    { 137, 5, "C7" },
                    { 130, 5, "B10" },
                    { 138, 5, "C8" },
                    { 140, 5, "C10" },
                    { 141, 5, "D1" },
                    { 142, 5, "D2" },
                    { 143, 5, "D3" },
                    { 144, 5, "D4" },
                    { 145, 5, "D5" },
                    { 146, 5, "D6" },
                    { 139, 5, "C9" },
                    { 129, 5, "B9" },
                    { 128, 5, "B8" },
                    { 127, 5, "B7" },
                    { 113, 4, "E3" },
                    { 114, 4, "E4" },
                    { 115, 4, "E5" },
                    { 116, 4, "E6" },
                    { 117, 4, "E7" },
                    { 118, 4, "E8" },
                    { 72, 4, "A2" },
                    { 120, 4, "E10" },
                    { 151, 5, "E1" },
                    { 150, 5, "D10" },
                    { 149, 5, "D9" },
                    { 121, 5, "B1" },
                    { 122, 5, "B2" },
                    { 123, 5, "B3" },
                    { 124, 5, "B4" },
                    { 125, 5, "B5" },
                    { 126, 5, "B6" },
                    { 111, 4, "E1" },
                    { 71, 4, "A1" },
                    { 65, 3, "C3" },
                    { 153, 5, "E3" },
                    { 21, 1, "C1" },
                    { 22, 1, "C2" },
                    { 23, 1, "C3" },
                    { 24, 1, "C4" },
                    { 25, 1, "C5" },
                    { 26, 1, "C6" },
                    { 27, 1, "C7" },
                    { 20, 1, "B10" },
                    { 28, 1, "C8" },
                    { 30, 1, "C10" },
                    { 160, 5, "E10" },
                    { 159, 5, "E9" },
                    { 31, 2, "A1" },
                    { 32, 2, "A2" },
                    { 33, 2, "A3" },
                    { 34, 2, "A4" },
                    { 29, 1, "C9" },
                    { 35, 2, "A5" },
                    { 19, 1, "B9" },
                    { 17, 1, "B7" },
                    { 1, 1, "A1" },
                    { 2, 1, "A2" },
                    { 3, 1, "A3" },
                    { 4, 1, "A4" },
                    { 5, 1, "A5" },
                    { 6, 1, "A6" },
                    { 7, 1, "A7" },
                    { 18, 1, "B8" },
                    { 8, 1, "A8" },
                    { 10, 1, "A10" },
                    { 11, 1, "B1" },
                    { 12, 1, "B2" },
                    { 13, 1, "B3" },
                    { 14, 1, "B4" },
                    { 15, 1, "B5" },
                    { 16, 1, "B6" },
                    { 9, 1, "A9" },
                    { 152, 5, "E2" },
                    { 36, 2, "A6" },
                    { 38, 2, "A8" },
                    { 55, 3, "B1" },
                    { 56, 3, "B2" },
                    { 57, 3, "B3" },
                    { 58, 3, "B4" },
                    { 59, 3, "B5" },
                    { 60, 3, "B6" },
                    { 61, 3, "B7" },
                    { 62, 3, "B8" },
                    { 63, 3, "C1" },
                    { 64, 3, "C2" },
                    { 147, 5, "D7" },
                    { 66, 3, "C4" },
                    { 67, 3, "C5" },
                    { 68, 3, "C6" },
                    { 69, 3, "C7" },
                    { 70, 3, "C8" },
                    { 154, 5, "E4" },
                    { 54, 3, "A8" },
                    { 37, 2, "A7" },
                    { 53, 3, "A7" },
                    { 51, 3, "A5" },
                    { 39, 2, "B1" },
                    { 40, 2, "B2" },
                    { 41, 2, "B3" },
                    { 42, 2, "B4" },
                    { 43, 2, "B5" },
                    { 44, 2, "B6" },
                    { 45, 2, "B7" },
                    { 52, 3, "A6" },
                    { 46, 2, "B8" },
                    { 157, 5, "E7" },
                    { 156, 5, "E6" },
                    { 155, 5, "E5" },
                    { 47, 3, "A1" },
                    { 48, 3, "A2" },
                    { 49, 3, "A3" },
                    { 50, 3, "A4" },
                    { 158, 5, "E8" },
                    { 148, 5, "D8" }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "ShowTimeId", "ScreenId", "ShowDateTime" },
                values: new object[,]
                {
                    { 14, 5, new DateTime(2019, 5, 27, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 3, new DateTime(2019, 5, 27, 15, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 4, new DateTime(2019, 5, 27, 19, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 4, new DateTime(2019, 5, 27, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 3, new DateTime(2019, 5, 27, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 5, new DateTime(2019, 5, 27, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, new DateTime(2019, 5, 27, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, new DateTime(2019, 5, 27, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, new DateTime(2019, 5, 27, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2019, 5, 27, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2019, 5, 27, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2019, 5, 27, 20, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2019, 5, 27, 17, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, new DateTime(2019, 5, 27, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 4, new DateTime(2019, 5, 27, 22, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 5, new DateTime(2019, 5, 27, 21, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MovieShowTime",
                columns: new[] { "MovieId", "ShowTimeId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 2, 8 },
                    { 1, 10 },
                    { 1, 13 },
                    { 1, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SeatId",
                table: "Bookings",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowTime_ShowTimeId",
                table: "MovieShowTime",
                column: "ShowTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ScreenId",
                table: "Seats",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_ScreenId",
                table: "ShowTimes",
                column: "ScreenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "MovieShowTime");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "ShowTimes");

            migrationBuilder.DropTable(
                name: "Screens");
        }
    }
}
