using Application.Interface.Context;
using Domain.Person;
using Domain.User;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class DataBaseContext : DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UsersInRoles { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //seed to entities
            builder.Entity<Role>().HasData(new Role { ID = 1, Name = nameof(UserRoles.Admin) });
            builder.Entity<Role>().HasData(new Role { ID = 2, Name = nameof(UserRoles.User) });
            
            builder.Entity<User>().HasData(new User { ID = 1, UserName = "Admin", Password = "ad1234" });
            builder.Entity<User>().HasData(new User { ID = 2, UserName = "User", Password = "us1234" });

            builder.Entity<UserInRole>().HasData(new UserInRole { ID = 1, RoleID = 1, UserID = 1 });
            builder.Entity<UserInRole>().HasData(new UserInRole { ID = 2, RoleID = 2, UserID = 2 });

            base.OnModelCreating(builder);
            //Configure one to many with OwnEntity
            builder.Entity<Person>(person =>
            {
                person.HasKey(p => p.Id);
                person.OwnsMany(p => p.Addresses, address =>
                {
                    address.WithOwner().HasForeignKey("PersonId");
                    address.HasKey("Id");
                    address.Property(a => a.Street).IsRequired();
                    address.Property(a => a.City).IsRequired();
                });
               
            });
          
            //Configure one to many 

            ////builder.Entity<Person>(person =>
            ////{
            ////    person.HasKey(p => p.Id);
            ////    person.Property(p => p.FullName).IsRequired();
            ////});

            ////builder.Entity<Address>(address =>
            ////{
            ////    address.HasKey(a => new { a.Street, a.City });
            ////    address.Property(a => a.Street).IsRequired();
            ////    address.Property(a => a.City).IsRequired();
            ////    address.HasOne<Person>()
            ////        .WithMany(p => p.Addresses)
            ////        .HasForeignKey(a => a.PersonId)
            ////        .OnDelete(DeleteBehavior.Cascade);
            ////});
        }
    }
}
