using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyTickets.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RouteId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Laguage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DepartureCity = table.Column<string>(nullable: true),
                    DepartureAirport = table.Column<string>(nullable: true),
                    DepartureTerminal = table.Column<string>(nullable: true),
                    ArivalCity = table.Column<string>(nullable: true),
                    ArivalAirport = table.Column<string>(nullable: true),
                    ArivalTerminal = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    Seats = table.Column<int>(nullable: false),
                    Plane = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
