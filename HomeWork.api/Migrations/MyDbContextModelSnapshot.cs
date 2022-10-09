﻿// <auto-generated />
using System;
using HomeWork.api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeWork.Api.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HomeWork.api.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("attendance_id");

                    b.Property<int>("AttendanceStatusId")
                        .HasColumnType("int")
                        .HasColumnName("attendance_attendance_status_id");

                    b.Property<float>("CountTime")
                        .HasColumnType("float")
                        .HasColumnName("attendance_count_time");

                    b.Property<DateTime>("RecordTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("attendance_record_time");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("attendance_staff_id");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceStatusId");

                    b.HasIndex("StaffId");

                    b.ToTable("T_Attendance", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.AttendanceStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("attandance_status_id");

                    b.Property<string>("EnumType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("attandance_status_type");

                    b.Property<int>("FineOrBouns")
                        .HasColumnType("int")
                        .HasColumnName("attendance_status_fine_or_bouns");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("attendance_status_is_deleted");

                    b.Property<float>("RateFineOrBouns")
                        .HasColumnType("float")
                        .HasColumnName("attendance_status_rate_fine_or_bouns");

                    b.HasKey("Id");

                    b.ToTable("T_AttendanceStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EnumType = "迟到",
                            FineOrBouns = 100,
                            IsDeleted = false,
                            RateFineOrBouns = 10f
                        },
                        new
                        {
                            Id = 2,
                            EnumType = "旷工",
                            FineOrBouns = 100,
                            IsDeleted = false,
                            RateFineOrBouns = 10f
                        },
                        new
                        {
                            Id = 3,
                            EnumType = "加班",
                            FineOrBouns = 100,
                            IsDeleted = false,
                            RateFineOrBouns = 10f
                        },
                        new
                        {
                            Id = 4,
                            EnumType = "请假",
                            FineOrBouns = 100,
                            IsDeleted = false,
                            RateFineOrBouns = 10f
                        });
                });

            modelBuilder.Entity("HomeWork.api.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("department_id");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("department_is_deleted");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int")
                        .HasColumnName("department_manager_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("department_name");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("T_Department", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.Political", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("political_id");

                    b.Property<string>("EnumType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("political_type");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("political_is_deleted");

                    b.HasKey("Id");

                    b.ToTable("T_Political", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EnumType = "党员",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            EnumType = "群众",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("HomeWork.api.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("post_is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("post_name");

                    b.Property<int?>("StandSalaryId")
                        .HasColumnType("int")
                        .HasColumnName("post_stand_salary");

                    b.HasKey("Id");

                    b.ToTable("T_Post", (string)null);
                });

            modelBuilder.Entity("HomeWork.Api.Models.SalaryRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("staff_record_id");

                    b.Property<float>("BasicSalary")
                        .HasColumnType("float")
                        .HasColumnName("staff_record_basic_salary");

                    b.Property<float>("Bouns")
                        .HasColumnType("float")
                        .HasColumnName("staff_record_bouns");

                    b.Property<DateTime>("CutOfTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("staff_record_cut_off_time");

                    b.Property<float>("Fine")
                        .HasColumnType("float")
                        .HasColumnName("staff_record_fine");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("staff_record_is_deleted");

                    b.Property<float>("Salary")
                        .HasColumnType("float")
                        .HasColumnName("staff_record_salary");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("staff_record_staff_id");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("staff_record_start_time");

                    b.HasKey("Id");

                    b.ToTable("T_StaffRecord", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("staff_id");

                    b.Property<DateTime>("Brith")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("staff_brith");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("staff_department_id");

                    b.Property<string>("Health")
                        .HasColumnType("longtext")
                        .HasColumnName("staff_health");

                    b.Property<string>("Introduce")
                        .HasColumnType("longtext")
                        .HasColumnName("staff_introduce");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("staff_is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("staff_name");

                    b.Property<int>("PoliticalType")
                        .HasColumnType("int")
                        .HasColumnName("staff_political_type");

                    b.Property<int?>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("staff_post_id");

                    b.Property<float?>("Salary")
                        .HasColumnType("float")
                        .HasColumnName("staff_salary");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PostId");

                    b.ToTable("T_Staff", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.StaffChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("staff_change_id");

                    b.Property<DateTime>("ChangeTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("staff_change_change_time");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("staff_change_department_id");

                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("staff_change_post_id");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("staff_change_staff_id");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("StaffId");

                    b.ToTable("T_StaffChange", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.StaffSalary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("salary_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit(1)");

                    b.Property<float>("Salary")
                        .HasColumnType("float")
                        .HasColumnName("salary_value");

                    b.HasKey("Id");

                    b.ToTable("T_StaffSalary", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.Attendance", b =>
                {
                    b.HasOne("HomeWork.api.Models.AttendanceStatus", null)
                        .WithMany()
                        .HasForeignKey("AttendanceStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWork.api.Models.Staff", null)
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeWork.api.Models.Department", b =>
                {
                    b.HasOne("HomeWork.api.Models.Staff", null)
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("HomeWork.api.Models.Staff", b =>
                {
                    b.HasOne("HomeWork.api.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("HomeWork.api.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("HomeWork.api.Models.StaffChange", b =>
                {
                    b.HasOne("HomeWork.api.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWork.api.Models.Staff", null)
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
