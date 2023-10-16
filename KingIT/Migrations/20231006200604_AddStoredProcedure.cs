using KingIT.EntitiesStatus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingIT.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            USE KingITCompany;

            GO
            CREATE PROCEDURE ADDPavilionRentTime AS
            BEGIN
            UPDATE Rents
            SET 
	            RentStart = DATEADD(YEAR, 1, RentEnd), 
	            RentEnd = DATEADD(YEAR, 1, RentEnd)

            UPDATE Pavilions 
	            SET 
		            StatusID = (SELECT ID FROM PavilionStatuses WHERE [Name] = 'Free')
            END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ADDPavilionRentTime')
                        DROP PROCEDURE ADDPavilionRentTime
                        GO");
        }
    }
}
