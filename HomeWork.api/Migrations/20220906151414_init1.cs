using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.api.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Department_T_Staff_ManagerId",
                table: "T_Department");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "T_Department",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Department_T_Staff_ManagerId",
                table: "T_Department",
                column: "ManagerId",
                principalTable: "T_Staff",
                principalColumn: "staff_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Department_T_Staff_ManagerId",
                table: "T_Department");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "T_Department",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Department_T_Staff_ManagerId",
                table: "T_Department",
                column: "ManagerId",
                principalTable: "T_Staff",
                principalColumn: "staff_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
