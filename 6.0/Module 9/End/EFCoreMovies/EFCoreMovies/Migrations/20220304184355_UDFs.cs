using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class UDFs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                CREATE FUNCTION InvoiceDetailSum
                                (
                                 @InvoiceId INT
                                )
                                RETURNS int
                                AS
                                BEGIN

                                DECLARE @sum INT;

                                SELECT @sum = SUM(price)
                                FROM InvoiceDetails
                                WHERE InvoiceId = @invoiceId

                                RETURN @sum

                                END");

            migrationBuilder.Sql(@"
                                CREATE FUNCTION InvoiceDetailAverage
                                (
                                @InvoiceId INT
                                )
                                RETURNS decimal(18,2)
                                AS
                                BEGIN
                                -- Declare the return variable here
                                DECLARE @average decimal(18,2);

                                -- Add the T-SQL statements to compute the return value here
                                SELECT @average = AVG(price)
                                FROM InvoiceDetails
                                where InvoiceId = @InvoiceId
	
                                -- Return the result of the function
                                RETURN @average

                                END

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [dbo].[InvoiceDetailSum]");
            migrationBuilder.Sql("DROP FUNCTION [dbo].[InvoiceDetailAverage]");

        }
    }
}
