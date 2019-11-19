using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CriAdmin.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Tier",
                columns: table => new
                {
                    TierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TierName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tier", x => x.TierId);
                });

            migrationBuilder.CreateTable(
                name: "CriQn",
                columns: table => new
                {
                    QnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qn = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Opt1 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Weight1 = table.Column<int>(nullable: false),
                    Opt2 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Weight2 = table.Column<int>(nullable: false),
                    Opt3 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Weight3 = table.Column<int>(nullable: true),
                    Opt4 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Weight4 = table.Column<int>(nullable: true),
                    CountryFk = table.Column<int>(nullable: false),
                    TierFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriQn", x => x.QnId);
                    table.ForeignKey(
                        name: "FK_CriQn_Country_CountryFk",
                        column: x => x.CountryFk,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriQn_Tier_TierFk",
                        column: x => x.TierFk,
                        principalTable: "Tier",
                        principalColumn: "TierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CriQn_CountryFk",
                table: "CriQn",
                column: "CountryFk");

            migrationBuilder.CreateIndex(
                name: "IX_CriQn_TierFk",
                table: "CriQn",
                column: "TierFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriQn");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Tier");
        }
    }
}
