using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimimInnovation.Data.Migrations
{
    public partial class According : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concords",
                columns: table => new
                {
                    ConcordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcordTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ConcordContinent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcordCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcordState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcordText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concords", x => x.ConcordId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concords");
        }
    }
}
