using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metrica1.Migrations
{
    public partial class Strin_Url_PATH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Employees",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Employees",
                newName: "ImageURL");
        }
    }
}
