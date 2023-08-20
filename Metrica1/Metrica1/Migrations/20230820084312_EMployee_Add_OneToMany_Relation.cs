using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metrica1.Migrations
{
    public partial class EMployee_Add_OneToMany_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AgencyId",
                table: "Employees",
                column: "AgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Agencies_AgencyId",
                table: "Employees",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Agencies_AgencyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AgencyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "Employees");
        }
    }
}
