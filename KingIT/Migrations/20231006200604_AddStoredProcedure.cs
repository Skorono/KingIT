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
            
            migrationBuilder.Sql(@"
            USE KingITCompany

            GO
            CREATE TRIGGER UPDATE_DELETE_BOOKED_PAVILIONS
            ON dbo.ShoppingCenters
            AFTER UPDATE
            AS
            BEGIN 
            IF ((SELECT StatusID FROM inserted) = 'P') AND ((SELECT StatusID FROM Pavilions WHERE ID = (SELECT ID FROM inserted)) = 'B')
	            ROLLBACK TRANSACTION
            END");
            
            migrationBuilder.Sql(@"
            USE KingITCompany

            GO
            CREATE TRIGGER UPDATE_DELETE_BOOKED_OR_RENTED_PAVILIONS
            ON dbo.Pavilions
            AFTER UPDATE
            AS
            BEGIN
            IF (SELECT StatusID FROM deleted) IN ('R', 'B')
	            ROLLBACK TRANSACTION
            END");
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
