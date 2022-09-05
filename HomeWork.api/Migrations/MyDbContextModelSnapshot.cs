﻿// <auto-generated />
using System;
using HomeWork.api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeWork.api.Migrations
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
                        .HasColumnType("int");

                    b.Property<float>("CountTime")
                        .HasColumnType("float")
                        .HasColumnName("count_time");

                    b.Property<DateTime>("RecordTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("record_time");

                    b.Property<int>("attendance_id")
                        .HasColumnType("int");

                    b.Property<int>("staff_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("attendance_id");

                    b.HasIndex("staff_id");

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

                    b.Property<float>("FineOrBouns")
                        .HasColumnType("float")
                        .HasColumnName("attendance_fine_or_bouns");

                    b.Property<float>("RateFineOrBouns")
                        .HasColumnType("float")
                        .HasColumnName("attendance_rate_fine_or_bouns");

                    b.HasKey("Id");

                    b.ToTable("T_AttendanceStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EnumType = "迟到",
                            FineOrBouns = 0f,
                            RateFineOrBouns = 0f
                        },
                        new
                        {
                            Id = 2,
                            EnumType = "旷工",
                            FineOrBouns = 0f,
                            RateFineOrBouns = 0f
                        },
                        new
                        {
                            Id = 3,
                            EnumType = "加班",
                            FineOrBouns = 0f,
                            RateFineOrBouns = 0f
                        },
                        new
                        {
                            Id = 4,
                            EnumType = "请假",
                            FineOrBouns = 0f,
                            RateFineOrBouns = 0f
                        });
                });

            modelBuilder.Entity("HomeWork.api.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("department_id");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("department_name");

                    b.HasKey("Id");

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

                    b.HasKey("Id");

                    b.ToTable("T_Political", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EnumType = "党员"
                        },
                        new
                        {
                            Id = 2,
                            EnumType = "群众"
                        });
                });

            modelBuilder.Entity("HomeWork.api.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("post_name");

                    b.Property<int>("saraly_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("saraly_id");

                    b.ToTable("T_Post", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("staff_id");

                    b.Property<DateTime>("Brith")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("staff_brithdate");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Health")
                        .HasColumnType("longtext")
                        .HasColumnName("staff_health");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("staff_name");

                    b.Property<int>("PoliticalTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.HasIndex("PoliticalTypeId");

                    b.HasIndex("PostId");

                    b.ToTable("T_Staff", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.StaffChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ChangeTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("change_time");

                    b.Property<int>("department_id")
                        .HasColumnType("int");

                    b.Property<int>("staff_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("department_id");

                    b.HasIndex("staff_id");

                    b.ToTable("T_StaffChange", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.StaffSalary", b =>
                {
                    b.Property<int>("SalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("salary_id");

                    b.Property<float>("Salary")
                        .HasColumnType("float")
                        .HasColumnName("salary_value");

                    b.HasKey("SalaryId");

                    b.ToTable("T_StaffSalary", (string)null);
                });

            modelBuilder.Entity("HomeWork.api.Models.Attendance", b =>
                {
                    b.HasOne("HomeWork.api.Models.AttendanceStatus", "AttendanceStatus")
                        .WithMany()
                        .HasForeignKey("attendance_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWork.api.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("staff_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttendanceStatus");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("HomeWork.api.Models.Post", b =>
                {
                    b.HasOne("HomeWork.api.Models.StaffSalary", "Saraly")
                        .WithMany()
                        .HasForeignKey("saraly_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Saraly");
                });

            modelBuilder.Entity("HomeWork.api.Models.Staff", b =>
                {
                    b.HasOne("HomeWork.api.Models.Department", "Department")
                        .WithOne("Manager")
                        .HasForeignKey("HomeWork.api.Models.Staff", "DepartmentId")
                        .IsRequired();

                    b.HasOne("HomeWork.api.Models.Political", "PoliticalType")
                        .WithMany()
                        .HasForeignKey("PoliticalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWork.api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("PoliticalType");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("HomeWork.api.Models.StaffChange", b =>
                {
                    b.HasOne("HomeWork.api.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWork.api.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("staff_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("HomeWork.api.Models.Department", b =>
                {
                    b.Navigation("Manager")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
