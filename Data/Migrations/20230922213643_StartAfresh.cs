using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimimInnovation.Data.Migrations
{
    public partial class StartAfresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF EXISTS(
                SELECT * FROM sys.columns 
                WHERE Name = N'DistanceFromMainRoad' 
                AND Object_ID = Object_ID(N'TimimProperties')
            )
            BEGIN
                ALTER TABLE TimimProperties DROP COLUMN DistanceFromMainRoad
            END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DistanceFromMainRoad",
                table: "TimimProperties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
