using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_AttendanceStatus",
                columns: table => new
                {
                    attandance_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    attendance_fine_or_bouns = table.Column<int>(type: "int", nullable: false),
                    attendance_rate_fine_or_bouns = table.Column<float>(type: "float", nullable: false),
                    attandance_status_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AttendanceStatus", x => x.attandance_status_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_Political",
                columns: table => new
                {
                    political_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    political_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Political", x => x.political_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_StaffSalary",
                columns: table => new
                {
                    salary_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    salary_value = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_StaffSalary", x => x.salary_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_Post",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    post_staff_salary_id = table.Column<int>(type: "int", nullable: false),
                    post_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Post", x => x.post_id);
                    table.ForeignKey(
                        name: "FK_T_Post_T_StaffSalary_post_staff_salary_id",
                        column: x => x.post_staff_salary_id,
                        principalTable: "T_StaffSalary",
                        principalColumn: "salary_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_Attendance",
                columns: table => new
                {
                    attendance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    attendance_staff_id = table.Column<int>(type: "int", nullable: false),
                    attendance_attendance_status_id = table.Column<int>(type: "int", nullable: false),
                    attendance_record_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    attendance_count_time = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Attendance", x => x.attendance_id);
                    table.ForeignKey(
                        name: "FK_T_Attendance_T_AttendanceStatus_attendance_attendance_status~",
                        column: x => x.attendance_attendance_status_id,
                        principalTable: "T_AttendanceStatus",
                        principalColumn: "attandance_status_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    department_manager_id = table.Column<int>(type: "int", nullable: true),
                    department_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Department", x => x.department_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_Staff",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    staff_brith = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    staff_political_type = table.Column<int>(type: "int", nullable: false),
                    staff_health = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    staff_post_id = table.Column<int>(type: "int", nullable: true),
                    staff_department_id = table.Column<int>(type: "int", nullable: true),
                    staff_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Staff", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_T_Staff_T_Department_staff_department_id",
                        column: x => x.staff_department_id,
                        principalTable: "T_Department",
                        principalColumn: "department_id");
                    table.ForeignKey(
                        name: "FK_T_Staff_T_Post_staff_post_id",
                        column: x => x.staff_post_id,
                        principalTable: "T_Post",
                        principalColumn: "post_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_StaffChange",
                columns: table => new
                {
                    staffchange_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    staffchange_staff_id = table.Column<int>(type: "int", nullable: false),
                    staffchange_department_id = table.Column<int>(type: "int", nullable: false),
                    staffchange_change_time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_StaffChange", x => x.staffchange_id);
                    table.ForeignKey(
                        name: "FK_T_StaffChange_T_Department_staffchange_department_id",
                        column: x => x.staffchange_department_id,
                        principalTable: "T_Department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_StaffChange_T_Staff_staffchange_staff_id",
                        column: x => x.staffchange_staff_id,
                        principalTable: "T_Staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "T_AttendanceStatus",
                columns: new[] { "attandance_status_id", "attandance_status_type", "attendance_fine_or_bouns", "attendance_rate_fine_or_bouns" },
                values: new object[,]
                {
                    { 1, "迟到", 100, 10f },
                    { 2, "旷工", 100, 10f },
                    { 3, "加班", 100, 10f },
                    { 4, "请假", 100, 10f }
                });

            migrationBuilder.InsertData(
                table: "T_Political",
                columns: new[] { "political_id", "political_type" },
                values: new object[,]
                {
                    { 1, "党员" },
                    { 2, "群众" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Attendance_attendance_attendance_status_id",
                table: "T_Attendance",
                column: "attendance_attendance_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Attendance_attendance_staff_id",
                table: "T_Attendance",
                column: "attendance_staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Department_department_manager_id",
                table: "T_Department",
                column: "department_manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Post_post_staff_salary_id",
                table: "T_Post",
                column: "post_staff_salary_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Staff_staff_department_id",
                table: "T_Staff",
                column: "staff_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Staff_staff_post_id",
                table: "T_Staff",
                column: "staff_post_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_StaffChange_staffchange_department_id",
                table: "T_StaffChange",
                column: "staffchange_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_StaffChange_staffchange_staff_id",
                table: "T_StaffChange",
                column: "staffchange_staff_id");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Attendance_T_Staff_attendance_staff_id",
                table: "T_Attendance",
                column: "attendance_staff_id",
                principalTable: "T_Staff",
                principalColumn: "staff_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Department_T_Staff_department_manager_id",
                table: "T_Department",
                column: "department_manager_id",
                principalTable: "T_Staff",
                principalColumn: "staff_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Department_T_Staff_department_manager_id",
                table: "T_Department");

            migrationBuilder.DropTable(
                name: "T_Attendance");

            migrationBuilder.DropTable(
                name: "T_Political");

            migrationBuilder.DropTable(
                name: "T_StaffChange");

            migrationBuilder.DropTable(
                name: "T_AttendanceStatus");

            migrationBuilder.DropTable(
                name: "T_Staff");

            migrationBuilder.DropTable(
                name: "T_Department");

            migrationBuilder.DropTable(
                name: "T_Post");

            migrationBuilder.DropTable(
                name: "T_StaffSalary");
        }
    }
}
