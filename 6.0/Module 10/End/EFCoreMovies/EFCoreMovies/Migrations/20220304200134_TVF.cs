using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class TVF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE FUNCTION MovieWithCounts
(
 @movieId int
)
RETURNS TABLE
AS
RETURN
(
Select Id, Title,
(Select count(*) FROM GenreMovie where MoviesId = movies.Id) as AmountGenres,
(Select count(distinct moviesId) from CinemaHallMovie
	INNER JOIN CinemaHalls
	ON CinemaHalls.Id = CinemaHallMovie.CinemaHallsId
	where MoviesId = movies.Id) as AmountCinemas,
(Select count(*) from MoviesActors where MovieId = movies.Id) as AmountActors
FROM Movies
where id = @movieId
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION MovieWithCounts");
        }
    }
}
