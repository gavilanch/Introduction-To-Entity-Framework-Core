using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE Genres_GetById
                                    @id int
                                    AS
                                    BEGIN
                                    SET NOCOUNT ON;

                                    SELECT *
                                    FROM Genres
                                    WHERE Id = @id;
                                    END");

            migrationBuilder.Sql(@"CREATE PROCEDURE Genres_Insert
                                    @name nvarchar(150),
                                    @id int OUTPUT
                                    AS
                                    BEGIN
                                    SET NOCOUNT ON;

                                    INSERT INTO Genres(Name)
                                    VALUES (@name);

                                    SELECT @id = SCOPE_IDENTITY();
                                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[Genres_GetById]");
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[Genres_Insert]");
        }

    }
}
