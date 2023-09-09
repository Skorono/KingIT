using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KingIT.Migrations
{
    /// <inheritdoc />
    public partial class StartupMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PavilionStatuses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PavilionStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCenterStatuses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCenterStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCenters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    AddedCoefficient = table.Column<float>(type: "real", nullable: false),
                    FloorsCount = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StatusID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TownID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCenters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCenters_ShoppingCenterStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "ShoppingCenterStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCenters_Towns_TownID",
                        column: x => x.TownID,
                        principalTable: "Towns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_UserStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "UserStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pavilions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    Square = table.Column<float>(type: "real", nullable: false),
                    SquareMeterCost = table.Column<int>(type: "int", nullable: false),
                    AddedCoefficient = table.Column<float>(type: "real", nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ShoppingСenterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pavilions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pavilions_PavilionStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "PavilionStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pavilions_ShoppingCenters_ShoppingСenterID",
                        column: x => x.ShoppingСenterID,
                        principalTable: "ShoppingCenters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PavilionStaff",
                columns: table => new
                {
                    PavilionID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PavilionStaff_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PavilionStaff_Pavilions_PavilionID",
                        column: x => x.PavilionID,
                        principalTable: "Pavilions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    RentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalID = table.Column<int>(type: "int", nullable: false),
                    PavilionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.RentID);
                    table.ForeignKey(
                        name: "FK_Rents_Pavilions_PavilionID",
                        column: x => x.PavilionID,
                        principalTable: "Pavilions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Rentals_RentalID",
                        column: x => x.RentalID,
                        principalTable: "Rentals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PavilionStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "B", "Booked" },
                    { "D", "Deleted" },
                    { "F", "Free" },
                    { "R", "Rented" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "A", "Administrator" },
                    { "M", "Manager" },
                    { "U", "User" }
                });

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "A", "Active" },
                    { "B", "Blocked" },
                    { "F", "Freezed" }
                });
            
            migrationBuilder.InsertData(
                table: "ShoppingCenterStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "P", "Plan" },
                    { "C", "Construction" },
                    { "R", "Realization" }
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID",
                table: "Employees",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StatusID",
                table: "Employees",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Pavilions_ShoppingСenterID",
                table: "Pavilions",
                column: "ShoppingСenterID");

            migrationBuilder.CreateIndex(
                name: "IX_Pavilions_StatusID",
                table: "Pavilions",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_PavilionStaff_EmployeeID",
                table: "PavilionStaff",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PavilionStaff_PavilionID",
                table: "PavilionStaff",
                column: "PavilionID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_PavilionID",
                table: "Rents",
                column: "PavilionID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RentalID",
                table: "Rents",
                column: "RentalID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCenters_StatusID",
                table: "ShoppingCenters",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCenters_TownID",
                table: "ShoppingCenters",
                column: "TownID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PavilionStaff");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Pavilions");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserStatuses");

            migrationBuilder.DropTable(
                name: "PavilionStatuses");

            migrationBuilder.DropTable(
                name: "ShoppingCenters");

            migrationBuilder.DropTable(
                name: "ShoppingCenterStatuses");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
