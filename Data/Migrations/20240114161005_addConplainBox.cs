using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimimInnovation.Data.Migrations
{
    public partial class addConplainBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimimComplaintBoxes",
                columns: table => new
                {
                    TimimComplaintBoxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyOwnerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PropertyOwnerPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PropertyOwnerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PropertyAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantFullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Complain = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ComplainDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimimComplaintBoxes", x => x.TimimComplaintBoxId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimimComplaintBoxes");
        }
    }
}
