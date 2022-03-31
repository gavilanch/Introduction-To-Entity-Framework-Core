using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class CinemaDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeOfConduct",
                table: "Cinemas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "History",
                table: "Cinemas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Missions",
                table: "Cinemas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Values",
                table: "Cinemas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeOfConduct",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "History",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Missions",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Values",
                table: "Cinemas");
        }
    }
}
