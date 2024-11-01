﻿using System;
using System.Collections.Generic;
using EmployeeProfile.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProfile.Data;

public partial class HrdbContext : DbContext
{
    public HrdbContext()
    {
    }

    public HrdbContext(DbContextOptions<HrdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server= smkk03; database=HRDB;trusted_connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__Departme__72A8C6A4100FC92D");

            entity.ToTable("Department");

            entity.Property(e => e.DeptId).HasColumnName("Dept_id");
            entity.Property(e => e.Department1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Department");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__2623598B3A2F343B");

            entity.Property(e => e.EmpId).HasColumnName("Emp_ID");
            entity.Property(e => e.DeptId).HasColumnName("Dept_ID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Emp_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Employees__Dept___267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
