using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIDM3312_FINALPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    TicketHistory = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Search = table.Column<string>(type: "TEXT", nullable: true),
                    Management = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTicket",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketsTicketID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTicket", x => new { x.CustomersId, x.TicketsTicketID });
                    table.ForeignKey(
                        name: "FK_CustomerTicket_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerTicket_Tickets_TicketsTicketID",
                        column: x => x.TicketsTicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTicket_TicketsTicketID",
                table: "CustomerTicket",
                column: "TicketsTicketID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTicket");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
