using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimimInnovation.Data.Migrations
{
    public partial class TCA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TermAndConditions",
                columns: table => new
                {
                    TermAndConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ClientUsername = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ClientFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TermAndConditionText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Agreement = table.Column<bool>(type: "bit", nullable: false),
                    SignDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermAndConditions", x => x.TermAndConditionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TermAndConditions");
        }
    }
}
