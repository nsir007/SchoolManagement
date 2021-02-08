using EducationalSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text;
using VM;

namespace Data.Student
{
    public class StudentContext : DbContext
    {
        private readonly string connectionString;

        public StudentContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public virtual DbSet<AttendanceDetail> AttendanceDetails { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<DateSheet> DateSheets { get; set; }
        public virtual DbSet<FeesDefaulter_> FeesDefaulter_ { get; set; }
        public virtual DbSet<FeesPayed_> FeesPayed_ { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Results_> Results_ { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<School_info> School_info { get; set; }
        public virtual DbSet<student_info> student_info { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TemplateConfig> TemplateConfigs { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<SubjectViewModel>();
            modelBuilder.Ignore<ClassViewModel>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Query<ClassViewModel>();

        }
    }
}
