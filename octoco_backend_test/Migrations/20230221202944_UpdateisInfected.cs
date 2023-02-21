using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace octoco_backend_test.Migrations
{
    public partial class UpdateisInfected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isInfected",
                table: "Survivors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isInfected",
                table: "Survivors");
        }
    }
}
