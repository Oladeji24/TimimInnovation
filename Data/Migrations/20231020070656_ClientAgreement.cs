using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimimInnovation.Data.Migrations
{
    public partial class ClientAgreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientConcords",
                columns: table => new
                {
                    ClientConcordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientConcordServiceType = table.Column<int>(type: "int", nullable: true),
                    ClientConcordTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ClientConcordText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientConcords", x => x.ClientConcordId);
                });

            migrationBuilder.CreateTable(
                name: "ClientTermAndConditions",
                columns: table => new
                {
                    ClientTermAndConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientTermAndConditionUsername = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ClientTermAndConditionFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientTermAndConditionLastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientTermAndConditionDecision = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SignDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTermAndConditions", x => x.ClientTermAndConditionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientConcords");

            migrationBuilder.DropTable(
                name: "ClientTermAndConditions");
        }
    }
}
