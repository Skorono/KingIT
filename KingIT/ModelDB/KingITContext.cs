﻿using System.Collections.Generic;
using System.Reflection;
using KingIT.EntitiesStatus;
using Microsoft.EntityFrameworkCore;

namespace KingIT.ModelDB;

public class KingITContext : DbContext
{
    public KingITContext()
    {
    }

    public KingITContext(DbContextOptions<KingITContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<UserStatus> UserStatuses { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Pavilion> Pavilions { get; set; }
    public virtual DbSet<PavilionStaff> PavilionStaff { get; set; }
    public virtual DbSet<PavilionStatus> PavilionStatuses { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }
    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<ShoppingСenter> ShoppingCenters { get; set; }
    public virtual DbSet<ShoppingCenterStatus> ShoppingCenterStatuses { get; set; }
    public virtual DbSet<Town> Towns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=KingITCompany;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Role>().HasData(EntityBuilder.GetData<Role>(typeof(UserTypes)));*/

        var RoleDataType = typeof(UserTypes);
        var Data = new List<Role>();
        foreach (var roleField in RoleDataType.GetFields(BindingFlags.Public | BindingFlags.Static))
            Data.Add(new Role { ID = (char)roleField.GetValue(RoleDataType)!, Name = roleField.Name });
        modelBuilder.Entity<Role>().HasData(Data);

        var PavilionDataType = typeof(PavilionStatuses);
        var Data1 = new List<PavilionStatus>();
        foreach (var statusField in PavilionDataType.GetFields(BindingFlags.Public | BindingFlags.Static))
            Data1.Add(new PavilionStatus
                { ID = (char)statusField.GetValue(PavilionDataType)!, Name = statusField.Name });
        modelBuilder.Entity<PavilionStatus>().HasData(Data1);


        var AccountStatuses = typeof(AccountStatuses);
        var Data2 = new List<UserStatus>();
        foreach (var statusField in AccountStatuses.GetFields(BindingFlags.Public | BindingFlags.Static))
            Data2.Add(new UserStatus { ID = (char)statusField.GetValue(AccountStatuses)!, Name = statusField.Name });
        modelBuilder.Entity<UserStatus>().HasData(Data2);

        var ShoppingCentersStatus1 = typeof(ShoppingCenterStatuses);
        var Data3 = new List<ShoppingCenterStatus>();
        foreach (var statusField in ShoppingCentersStatus1.GetFields(BindingFlags.Public | BindingFlags.Static))
            Data3.Add(new ShoppingCenterStatus
                { ID = (char)statusField.GetValue(AccountStatuses)!, Name = statusField.Name });
        modelBuilder.Entity<ShoppingCenterStatus>().HasData(Data3);

        modelBuilder.Entity<Employee>();
        modelBuilder.Entity<Pavilion>();
        modelBuilder.Entity<PavilionStaff>();
        modelBuilder.Entity<PavilionStaff>().HasKey(u => new {u.PavilionID, u.EmployeeID});
        modelBuilder.Entity<Rental>();
        modelBuilder.Entity<Rent>();
        modelBuilder.Entity<ShoppingСenter>();
        modelBuilder.Entity<Town>();
    }
}