using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class Module3Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Biography", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, "Thomas Stanley Holland (born 1 June 1996) is an English actor. He is recipient of several accolades, including the 2017 BAFTA Rising Star Award. Holland began his acting career as a child actor on the West End stage in Billy Elliot the Musical at the Victoria Palace Theatre in 2008, playing a supporting part", new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Holland" },
                    { 2, "Samuel Leroy Jackson (born December 21, 1948) is an American actor and producer. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time (excluding cameo appearances and voice roles).", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel L. Jackson" },
                    { 3, "Robert John Downey Jr. (born April 4, 1965) is an American actor and producer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr." },
                    { 4, null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Evans" },
                    { 5, null, new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne Johnson" },
                    { 6, null, new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auli'i Cravalho" },
                    { 7, null, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlett Johansson" },
                    { 8, null, new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu Reeves" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)"), "Agora Mall" },
                    { 2, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.911582 18.482455)"), "Sambil" },
                    { 3, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856309 18.506662)"), "Megacentro" },
                    { 4, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.939248 18.469649)"), "Acropolis" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Animation" },
                    { 3, "Comedy" },
                    { 4, "Science Fiction" },
                    { 5, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "InCinemas", "PosterURL", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, false, "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers" },
                    { 2, false, "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg", new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coco" },
                    { 3, false, "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: No way home" },
                    { 4, false, "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: Far From Home" },
                    { 5, true, "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix Resurrections" }
                });

            migrationBuilder.InsertData(
                table: "CinemaHalls",
                columns: new[] { "Id", "CinemaHallType", "CinemaId", "Cost" },
                values: new object[,]
                {
                    { 1, 1, 1, 220m },
                    { 2, 2, 1, 320m },
                    { 3, 1, 2, 200m },
                    { 4, 2, 2, 290m },
                    { 5, 1, 3, 250m },
                    { 6, 2, 3, 330m },
                    { 7, 3, 3, 450m },
                    { 8, 1, 4, 250m }
                });

            migrationBuilder.InsertData(
                table: "CinemaOffers",
                columns: new[] { "Id", "Begin", "CinemaId", "DiscountPercentage", "End" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10m, new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 15m, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenresId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "MoviesActors",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[,]
                {
                    { 3, 1, "Iron Man", 2 },
                    { 4, 1, "Capitán América", 1 },
                    { 7, 1, "Black Widow", 3 },
                    { 1, 3, "Peter Parker", 1 },
                    { 1, 4, "Peter Parker", 1 },
                    { 2, 4, "Samuel L. Jackson", 2 },
                    { 8, 5, "Neo", 1 }
                });

            migrationBuilder.InsertData(
                table: "CinemaHallMovie",
                columns: new[] { "CinemaHallsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 4, 5 },
                    { 5, 5 },
                    { 6, 5 },
                    { 7, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
