using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "products.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creating relation
            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address);

            modelBuilder.Entity<ProductEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Products)
                .HasForeignKey(e => e.OrganizationId);

            // Sample data for Organization Entity

            modelBuilder.Entity<OrganizationEntity>().HasData(
                new OrganizationEntity()
                {
                    Id = 1,
                    Title = "WSEI",
                    Nip = "83492384",
                    Regon = "13424234",
                },

                new OrganizationEntity()
                {
                    Id = 2,
                    Title = "Firma",
                    Nip = "2498534",
                    Regon = "0873439249",
                }
            );;

            // Sample data for Product Entity

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity()
                {
                    Id = 1,
                    Name = "Product 1",
                    Price = 10.99m,
                    Producer = "Producer 1",
                    ProductionDate = new DateTime(2020, 10, 10),
                    Description = "Product 1 description",
                    OrganizationId = 1
                },
                new ProductEntity()
                {
                    Id = 2,
                    Name = "Product 2",
                    Price = 20.99m,
                    Producer = "Producer 2",
                    ProductionDate = new DateTime(2023, 10, 10),
                    Description = "Product 2 description",
                    OrganizationId = 2
                }
            );

            // Sample Address Data

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address)
                .HasData(
                    new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                    new { OrganizationEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
                );
        }
    }
}
