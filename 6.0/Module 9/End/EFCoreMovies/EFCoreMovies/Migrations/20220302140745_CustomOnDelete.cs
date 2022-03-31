using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class CustomOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Cinemas_TheCinemaId",
                table: "CinemaHalls");

            migrationBuilder.AlterColumn<int>(
                name: "TheCinemaId",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Cinemas_TheCinemaId",
                table: "CinemaHalls",
                column: "TheCinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Cinemas_TheCinemaId",
                table: "CinemaHalls");

            migrationBuilder.AlterColumn<int>(
                name: "TheCinemaId",
                table: "CinemaHalls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Cinemas_TheCinemaId",
                table: "CinemaHalls",
                column: "TheCinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }
    }
}
