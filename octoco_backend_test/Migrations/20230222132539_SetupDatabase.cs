using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace octoco_backend_test.Migrations
{
    public partial class SetupDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Survivors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Inventory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isInfected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survivors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Survivors",
                columns: new[] { "Id", "Age", "Gender", "Inventory", "Latitude", "Longitude", "Name", "isInfected" },
                values: new object[] { 1, 26, 0, "{\"Water Bottles\":5,\"Ammo\":49,\"Guns\":1}", -32.241844, 22.299499999999998, "John", false });

            migrationBuilder.InsertData(
                table: "Survivors",
                columns: new[] { "Id", "Age", "Gender", "Inventory", "Latitude", "Longitude", "Name", "isInfected" },
                values: new object[] { 2, 33, 1, "{\"Food\":10,\"Medicine\":2,\"Ammo\":15}", 40.712775999999998, -74.005973999999995, "Mary", true });

            migrationBuilder.InsertData(
                table: "Survivors",
                columns: new[] { "Id", "Age", "Gender", "Inventory", "Latitude", "Longitude", "Name", "isInfected" },
                values: new object[] { 3, 45, 0, "{\"Water Bottles\":2,\"Gasoline\":5}", 51.507351, -0.12775800000000001, "Tom", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Survivors");
        }
    }
}
