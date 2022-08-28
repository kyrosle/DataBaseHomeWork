using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.api.Migrations
{
    public partial class managerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manager",
                table: "T_Department",
                newName: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "T_Department",
                newName: "Manager");
        }
    }
}
