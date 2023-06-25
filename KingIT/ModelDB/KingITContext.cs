using KingIT.EntitiesStatus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

namespace KingIT.ModelDB
{
    public class KingITContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<UserStatus> UserStatuses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Pavilion> Pavilions { get; set; }
        public virtual DbSet<PavilionStaff> PavilionStaff { get; set; }
        public virtual DbSet<PavilionStatus> PavilionStatuses { get; set; }

        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }

        public virtual DbSet<ShoppingСenter> ShoppingCenters { get; set; }
        public virtual DbSet<ShopingCenterStatus> ShoppingCenterStatuses { get; set; }
        public virtual DbSet<Town> Towns { get; set; }


        public KingITContext() { }

        public KingITContext(DbContextOptions<KingITContext> options)
       : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=KingIT;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Role>().HasData(EntityBuilder.GetData<Role>(typeof(UserTypes)));*/

            var RoleDataType = typeof(UserTypes); 
            List<Role> Data = new List<Role>();
            foreach (var roleField in RoleDataType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                Data.Add(new Role { ID = (char)roleField.GetValue(RoleDataType)!, Name = roleField.Name });
            }
            modelBuilder.Entity<Role>().HasData(Data);

            var PavilionDataType = typeof(PavilionStatuses);
            List<PavilionStatus> Data1 = new List<PavilionStatus>();
            foreach (var statusField in PavilionDataType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                Data1.Add(new PavilionStatus { ID = (char)statusField.GetValue(PavilionDataType)!, Name = statusField.Name });
            }
            modelBuilder.Entity<PavilionStatus>().HasData(Data1);


            var AccountStatuses = typeof(AccountStatuses);
            List<UserStatus> Data2 = new List<UserStatus>();
            foreach (var statusField in AccountStatuses.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                Data2.Add(new UserStatus { ID = (char)statusField.GetValue(AccountStatuses)!, Name = statusField.Name });
            }
            modelBuilder.Entity<UserStatus>().HasData(Data2);

        }
    }
}
