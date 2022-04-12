using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleProject.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    CoinID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueInEUR = table.Column<double>(type: "float", nullable: false),
                    ValueInUSD = table.Column<double>(type: "float", nullable: false),
                    ValueInBTC = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.CoinID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
