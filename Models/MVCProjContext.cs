﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models;

public partial class MVCProjContext : DbContext
{
    public MVCProjContext()
    {
    }

    public MVCProjContext(DbContextOptions<MVCProjContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<PhoneProgram> Programs { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= !!!! ;Database=mvcproject;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE488679D989D");

            entity.HasOne(d => d.User).WithMany(p => p.Admins).HasConstraintName("FK_Admins_Users");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bills__11F2FC6A31FF3D88");

            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.Bills).HasConstraintName("FK_Bills_Phones");

            entity.HasMany(d => d.Calls).WithMany(p => p.Bills)
                .UsingEntity<Dictionary<string, object>>(
                    "BillsCall",
                    r => r.HasOne<Call>().WithMany()
                        .HasForeignKey("CallId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Bills_Calls_2"),
                    l => l.HasOne<Bill>().WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Bills_Calls_1"),
                    j =>
                    {
                        j.HasKey("BillId", "CallId").HasName("PK__BillsCal__A4EAF0900152B373");
                        j.ToTable("BillsCalls");
                    });
        });

        modelBuilder.Entity<Call>(entity =>
        {
            entity.HasKey(e => e.CallId).HasName("PK__Calls__5180CFAA3B784961");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__E67E1A241604E31A");

            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.Clients).HasConstraintName("FK_Clients_Phones");

            entity.HasOne(d => d.User).WithMany(p => p.Clients).HasConstraintName("FK_Clients_Users");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.PhoneNumber).HasName("PK__Phones__85FB4E3908350722");
        });

        modelBuilder.Entity<PhoneProgram>(entity =>
        {
            entity.HasKey(e => e.ProgramName).HasName("PK__Programs__4F92571127F01944");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.SellerId).HasName("PK__Sellers__7FE3DB81ADCB3538");

            entity.HasOne(d => d.User).WithMany(p => p.Sellers).HasConstraintName("FK_Sellers_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CE071A783");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
