﻿// <auto-generated />
using System;
using Data.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Student.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20210108161144_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EducationalSystem.Models.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("CreatedUserId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("UpdateOn");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("AttendanceId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EducationalSystem.Models.AttendanceDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendanceId");

                    b.Property<string>("Reason");

                    b.Property<string>("Status");

                    b.Property<int>("StudentId");

                    b.HasKey("DetailId");

                    b.HasIndex("AttendanceId");

                    b.ToTable("AttendanceDetails");
                });

            modelBuilder.Entity("EducationalSystem.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("EducationalSystem.Models.DateSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.ToTable("DateSheets");
                });

            modelBuilder.Entity("EducationalSystem.Models.FeesDefaulter_", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date");

                    b.Property<int?>("s_id");

                    b.Property<int?>("student_infoid");

                    b.HasKey("ID");

                    b.HasIndex("student_infoid");

                    b.ToTable("FeesDefaulter_");
                });

            modelBuilder.Entity("EducationalSystem.Models.FeesPayed_", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Added_by");

                    b.Property<DateTime?>("Date");

                    b.Property<int?>("Discount");

                    b.Property<int?>("Payed");

                    b.Property<int?>("Remaining");

                    b.Property<DateTime?>("Time");

                    b.Property<int?>("Total");

                    b.Property<DateTime?>("UpdateOn");

                    b.Property<int?>("s_id");

                    b.Property<int?>("student_infoid");

                    b.HasKey("ID");

                    b.HasIndex("student_infoid");

                    b.ToTable("FeesPayed_");
                });

            modelBuilder.Entity("EducationalSystem.Models.Instruction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("EducationalSystem.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<bool>("In_menu");

                    b.Property<string>("Name");

                    b.Property<int>("ParentId");

                    b.Property<string>("URL");

                    b.Property<bool>("is_user");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("EducationalSystem.Models.Results_", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Added_by");

                    b.Property<DateTime?>("Datee");

                    b.Property<string>("classs");

                    b.Property<string>("grade");

                    b.Property<double?>("obtain");

                    b.Property<double?>("persentage");

                    b.Property<int?>("sid");

                    b.Property<string>("subject");

                    b.Property<double>("total");

                    b.HasKey("ID");

                    b.ToTable("Results_");
                });

            modelBuilder.Entity("EducationalSystem.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedBy");

                    b.Property<DateTime?>("Created_at");

                    b.Property<DateTime?>("Deleted_at");

                    b.Property<string>("Description");

                    b.Property<bool?>("Enable");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated_at");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EducationalSystem.Models.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionID");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionID");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("EducationalSystem.Models.School_info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Code");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("FullName");

                    b.Property<string>("Logo");

                    b.Property<string>("Machine");

                    b.Property<string>("MobileToken");

                    b.Property<string>("Phone");

                    b.Property<string>("Principle");

                    b.Property<string>("ShortName");

                    b.Property<string>("ShortSPEL");

                    b.HasKey("Id");

                    b.ToTable("School_info");
                });

            modelBuilder.Entity("EducationalSystem.Models.student_info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Admited_Class");

                    b.Property<string>("Admited_by");

                    b.Property<int?>("Admn_fee");

                    b.Property<string>("Cast");

                    b.Property<string>("Class");

                    b.Property<string>("ClassRoll");

                    b.Property<DateTime?>("Date_of_admn");

                    b.Property<DateTime?>("Date_of_birth");

                    b.Property<string>("F_cnic");

                    b.Property<int?>("Family_id");

                    b.Property<string>("FatherName");

                    b.Property<string>("Father_ocupation");

                    b.Property<string>("Gender");

                    b.Property<int?>("Monthly_dues");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Refrence");

                    b.Property<string>("Religion");

                    b.Property<string>("S_cnic");

                    b.Property<int>("S_id");

                    b.Property<string>("Simg");

                    b.Property<DateTime?>("exit_date");

                    b.Property<bool?>("status");

                    b.HasKey("id");

                    b.ToTable("student_info");
                });

            modelBuilder.Entity("EducationalSystem.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("EducationalSystem.Models.Template", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("EducationalSystem.Models.TemplateConfig", b =>
                {
                    b.Property<int>("ConfigId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("CreatedUserId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("KeyCode");

                    b.Property<int>("TemplateId");

                    b.Property<DateTime?>("UpdateOn");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("ConfigId");

                    b.ToTable("TemplateConfigs");
                });

            modelBuilder.Entity("EducationalSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<bool?>("Enable");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Machine");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Password");

                    b.Property<string>("Picture");

                    b.Property<string>("UserName");

                    b.Property<DateTime?>("created_at");

                    b.Property<DateTime?>("deleted_at");

                    b.Property<bool?>("is_admin");

                    b.Property<string>("remember_token");

                    b.Property<DateTime?>("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EducationalSystem.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("EducationalSystem.Models.AttendanceDetail", b =>
                {
                    b.HasOne("EducationalSystem.Models.Attendance", "Attendance")
                        .WithMany("AttendanceDetails")
                        .HasForeignKey("AttendanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EducationalSystem.Models.DateSheet", b =>
                {
                    b.HasOne("EducationalSystem.Models.Class", "Class")
                        .WithMany("DateSheets")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EducationalSystem.Models.Subject", "Subject")
                        .WithMany("DateSheets")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EducationalSystem.Models.FeesDefaulter_", b =>
                {
                    b.HasOne("EducationalSystem.Models.student_info", "student_info")
                        .WithMany("FeesDefaulter_")
                        .HasForeignKey("student_infoid");
                });

            modelBuilder.Entity("EducationalSystem.Models.FeesPayed_", b =>
                {
                    b.HasOne("EducationalSystem.Models.student_info", "student_info")
                        .WithMany("FeesPayed_")
                        .HasForeignKey("student_infoid");
                });

            modelBuilder.Entity("EducationalSystem.Models.RolePermission", b =>
                {
                    b.HasOne("EducationalSystem.Models.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EducationalSystem.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EducationalSystem.Models.UserRole", b =>
                {
                    b.HasOne("EducationalSystem.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EducationalSystem.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
