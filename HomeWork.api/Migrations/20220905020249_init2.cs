using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.api.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_StaffSalary",
                keyColumn: "salary_id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "T_StaffSalary",
                columns: new[] { "salary_id", "salary_value" },
                values: new object[] { 1, 1000f });
        }
    }
}
