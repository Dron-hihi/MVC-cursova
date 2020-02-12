using CursovaMVC.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.EFContext
{
    public class EFDBContext : IdentityDbContext<DbUser, DbRole, string, IdentityUserClaim<string>,
DbUserRole, IdentityUserLogin<string>,
IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<House_Type> House_Types { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Sity> Sities { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Storage_Type> Storage_Types { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}

