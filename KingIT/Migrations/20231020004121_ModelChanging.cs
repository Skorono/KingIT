using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingIT.Migrations
{
    /// <inheritdoc />
    public partial class ModelChanging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Pavilions",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pavilions",
                newName: "Number");
        }
    }
}
