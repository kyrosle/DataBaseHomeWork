using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.api.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "T_Department",
                columns: new[] { "department_id", "department_manager_id", "department_name" },
                values: new object[,]
                {
                    { 1, 1, "Department1" },
                    { 2, 1, "Department2" }
                });

            migrationBuilder.InsertData(
                table: "T_Post",
                columns: new[] { "post_id", "post_name", "post_salary_id" },
                values: new object[,]
                {
                    { 1, "Post1", 1 },
                    { 2, "Post2", 1 }
                });

            migrationBuilder.InsertData(
                table: "T_Staff",
                columns: new[] { "staff_id", "staff_brithdate", "staff_department_id", "staff_health", "staff_name", "staff_political_type", "staff_post_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 3, 21, 58, 39, 250, DateTimeKind.Local).AddTicks(7796), 1, "good", "Staff1", 1, 1 },
                    { 2, new DateTime(2022, 9, 3, 21, 58, 39, 250, DateTimeKind.Local).AddTicks(7811), 2, "good", "Staff2", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "T_StaffSalary",
                columns: new[] { "salary_id", "salary_value" },
                values: new object[] { 1, 1000f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_Department",
                keyColumn: "department_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_Department",
                keyColumn: "department_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "T_Post",
                keyColumn: "post_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_Post",
                keyColumn: "post_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "T_Staff",
                keyColumn: "staff_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_Staff",
                keyColumn: "staff_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "T_StaffSalary",
                keyColumn: "salary_id",
                keyValue: 1);
        }
    }
}
