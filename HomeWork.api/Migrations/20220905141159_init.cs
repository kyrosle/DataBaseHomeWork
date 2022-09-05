using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.api.Migrations
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
                    attendance_fine_or_bouns = table.Column<float>(type: "float", nullable: false),
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
                name: "T_Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    department_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Department", x => x.department_id);
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
                    saraly_id = table.Column<int>(type: "int", nullable: false),
                    post_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Post", x => x.post_id);
                    table.ForeignKey(
                        name: "FK_T_Post_T_StaffSalary_saraly_id",
                        column: x => x.saraly_id,
                        principalTable: "T_StaffSalary",
                        principalColumn: "salary_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_Staff",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    staff_brithdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PoliticalTypeId = table.Column<int>(type: "int", nullable: false),
                    staff_health = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    staff_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Staff", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_T_Staff_T_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "T_Department",
                        principalColumn: "department_id");
                    table.ForeignKey(
                        name: "FK_T_Staff_T_Political_PoliticalTypeId",
                        column: x => x.PoliticalTypeId,
                        principalTable: "T_Political",
                        principalColumn: "political_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Staff_T_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "T_Post",
                        principalColumn: "post_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_Attendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    staff_id = table.Column<int>(type: "int", nullable: false),
                    attendance_id = table.Column<int>(type: "int", nullable: false),
                    record_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    count_time = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Attendance_T_AttendanceStatus_attendance_id",
                        column: x => x.attendance_id,
                        principalTable: "T_AttendanceStatus",
                        principalColumn: "attandance_status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Attendance_T_Staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "T_Staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_StaffChange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    staff_id = table.Column<int>(type: "int", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false),
                    change_time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_StaffChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_StaffChange_T_Department_department_id",
                        column: x => x.department_id,
                        principalTable: "T_Department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_StaffChange_T_Staff_staff_id",
                        column: x => x.staff_id,
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
                    { 1, "迟到", 0f, 0f },
                    { 2, "旷工", 0f, 0f },
                    { 3, "加班", 0f, 0f },
                    { 4, "请假", 0f, 0f }
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
                name: "IX_T_Attendance_attendance_id",
                table: "T_Attendance",
                column: "attendance_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Attendance_staff_id",
                table: "T_Attendance",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Post_saraly_id",
                table: "T_Post",
                column: "saraly_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Staff_DepartmentId",
                table: "T_Staff",
                column: "DepartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_Staff_PoliticalTypeId",
                table: "T_Staff",
                column: "PoliticalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Staff_PostId",
                table: "T_Staff",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_T_StaffChange_department_id",
                table: "T_StaffChange",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_StaffChange_staff_id",
                table: "T_StaffChange",
                column: "staff_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Attendance");

            migrationBuilder.DropTable(
                name: "T_StaffChange");

            migrationBuilder.DropTable(
                name: "T_AttendanceStatus");

            migrationBuilder.DropTable(
                name: "T_Staff");

            migrationBuilder.DropTable(
                name: "T_Department");

            migrationBuilder.DropTable(
                name: "T_Political");

            migrationBuilder.DropTable(
                name: "T_Post");

            migrationBuilder.DropTable(
                name: "T_StaffSalary");
        }
    }
}
