using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class Payments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    Last4Digits = table.Column<string>(type: "char(150)", maxLength: 150, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Last4Digits", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { 3, 15.99m, "4567", new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 19m, "1111", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "EmailAddress", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { 1, 123m, "felipe@hotmail.com", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 456m, "claudia@hotmail.com", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
