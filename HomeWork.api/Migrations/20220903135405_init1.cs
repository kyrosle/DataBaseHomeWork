using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.api.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "T_AttendanceStatus",
                keyColumn: "attandance_status_id",
                keyValue: 4,
                column: "attandance_status_type",
                value: "请假");

            migrationBuilder.InsertData(
                table: "T_Political",
                columns: new[] { "political_id", "political_type" },
                values: new object[] { 1, "党员" });

            migrationBuilder.InsertData(
                table: "T_Political",
                columns: new[] { "political_id", "political_type" },
                values: new object[] { 2, "群众" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_Political",
                keyColumn: "political_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_Political",
                keyColumn: "political_id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "T_AttendanceStatus",
                keyColumn: "attandance_status_id",
                keyValue: 4,
                column: "attandance_status_type",
                value: "");
        }
    }
}
