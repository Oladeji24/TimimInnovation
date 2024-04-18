using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimimInnovation.Data.Migrations
{
    public partial class TenancyTimimComplain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NIN",
                table: "TimimProperties",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TenantComplains",
                columns: table => new
                {
                    TenantComplainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TenantEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PropertyAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LandLordtFullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LandLoordNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TenantComplainText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ComplainDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantComplains", x => x.TenantComplainId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantComplains");

            migrationBuilder.DropColumn(
                name: "NIN",
                table: "TimimProperties");
        }
    }
}
