using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Promart_Crud.Models
{
    public partial class promartContext : DbContext
    {
        public promartContext()
        {
        }

        public promartContext(DbContextOptions<promartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=promart;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeAge).HasColumnName("employee_age");

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employee_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeSalary)
                    .HasColumnName("employee_salary")
                    .HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
