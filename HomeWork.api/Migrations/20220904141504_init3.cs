using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.api.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendanceStatusId",
                table: "T_Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "T_Staff",
                keyColumn: "staff_id",
                keyValue: 1,
                column: "staff_brithdate",
                value: new DateTime(2022, 9, 4, 22, 15, 4, 656, DateTimeKind.Local).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "T_Staff",
                keyColumn: "staff_id",
                keyValue: 2,
                column: "staff_brithdate",
                value: new DateTime(2022, 9, 4, 22, 15, 4, 656, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.CreateIndex(
                name: "IX_T_Attendance_AttendanceStatusId",
                table: "T_Attendance",
                column: "AttendanceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Attendance_staff_id",
                table: "T_Attendance",
                column: "staff_id");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Attendance_T_AttendanceStatus_AttendanceStatusId",
                table: "T_Attendance",
                column: "AttendanceStatusId",
                principalTable: "T_AttendanceStatus",
                principalColumn: "attandance_status_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Attendance_T_Staff_staff_id",
                table: "T_Attendance",
                column: "staff_id",
                principalTable: "T_Staff",
                principalColumn: "staff_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Attendance_T_AttendanceStatus_AttendanceStatusId",
                table: "T_Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_T_Attendance_T_Staff_staff_id",
                table: "T_Attendance");

            migrationBuilder.DropIndex(
                name: "IX_T_Attendance_AttendanceStatusId",
                table: "T_Attendance");

            migrationBuilder.DropIndex(
                name: "IX_T_Attendance_staff_id",
                table: "T_Attendance");

            migrationBuilder.DropColumn(
                name: "AttendanceStatusId",
                table: "T_Attendance");

            migrationBuilder.UpdateData(
                table: "T_Staff",
                keyColumn: "staff_id",
                keyValue: 1,
                column: "staff_brithdate",
                value: new DateTime(2022, 9, 3, 21, 58, 39, 250, DateTimeKind.Local).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "T_Staff",
                keyColumn: "staff_id",
                keyValue: 2,
                column: "staff_brithdate",
                value: new DateTime(2022, 9, 3, 21, 58, 39, 250, DateTimeKind.Local).AddTicks(7811));
        }
    }
}
