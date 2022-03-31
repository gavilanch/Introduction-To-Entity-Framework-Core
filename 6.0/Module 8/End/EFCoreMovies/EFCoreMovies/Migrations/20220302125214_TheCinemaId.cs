using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class TheCinemaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Cinemas_CinemaId",
                table: "CinemaHalls");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "CinemaHalls",
                newName: "TheCinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaHalls_CinemaId",
                table: "CinemaHalls",
                newName: "IX_CinemaHalls_TheCinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Cinemas_TheCinemaId",
                table: "CinemaHalls",
                column: "TheCinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Cinemas_TheCinemaId",
                table: "CinemaHalls");

            migrationBuilder.RenameColumn(
                name: "TheCinemaId",
                table: "CinemaHalls",
                newName: "CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaHalls_TheCinemaId",
                table: "CinemaHalls",
                newName: "IX_CinemaHalls_CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Cinemas_CinemaId",
                table: "CinemaHalls",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }
    }
}
