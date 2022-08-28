using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.api.Migrations
{
    public partial class setid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T_StaffChange",
                table: "T_StaffChange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Attendance",
                table: "T_Attendance");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "T_Attendance",
                newName: "staff_id");

            migrationBuilder.RenameColumn(
                name: "AttendanceDate",
                table: "T_Attendance",
                newName: "RecordTime");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "T_StaffChange",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "T_StaffChange",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "staff_id",
                table: "T_Attendance",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "T_Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "AttendTime",
                table: "T_Attendance",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_StaffChange",
                table: "T_StaffChange",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Attendance",
                table: "T_Attendance",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T_StaffChange",
                table: "T_StaffChange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Attendance",
                table: "T_Attendance");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "T_StaffChange");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "T_Attendance");

            migrationBuilder.DropColumn(
                name: "AttendTime",
                table: "T_Attendance");

            migrationBuilder.RenameColumn(
                name: "staff_id",
                table: "T_Attendance",
                newName: "StaffId");

            migrationBuilder.RenameColumn(
                name: "RecordTime",
                table: "T_Attendance",
                newName: "AttendanceDate");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "T_StaffChange",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "T_Attendance",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_StaffChange",
                table: "T_StaffChange",
                column: "StaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Attendance",
                table: "T_Attendance",
                column: "StaffId");
        }
    }
}
