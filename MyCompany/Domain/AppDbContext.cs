using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "BBD2743F-F15B-48C2-90B3-CAE32EDFD26A",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser { 
                Id = "",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "BBD2743F-F15B-48C2-90B3-CAE32EDFD26A",
                UserId = "DEFEA8C9-FDF1-4841-8C5F-CEB57EC5B38D"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8AE8F974-E5F5-4987-99BF-3C713003AD44"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("ED99A6EF-E55E-42B5-AE5C-E8CC51F5D67F"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("4934C9C8-55E9-498F-BA2B-0BFE2E2AC8AB"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
