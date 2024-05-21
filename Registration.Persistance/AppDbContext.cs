using Microsoft.EntityFrameworkCore;
using Registration.Domain.Entities;


namespace Registration.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Address> addresses { get; set; }

        public DbSet<GovernateCount> GovernateCounts { get; set; }

        public DbSet<CityEntity> Citys { get; set; }
        public DbSet<GovernateEntity> governates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(20);
                entity.Property(e => e.MiddleName).HasMaxLength(40);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(20);
                entity.Property(e => e.BirthDate).IsRequired();
                entity.Property(e => e.MobileNumber).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
                entity.HasMany(e => e.AddressList).WithOne().HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Governate).IsRequired().HasMaxLength(50);
                entity.Property(e => e.City).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Street).IsRequired().HasMaxLength(200);
                entity.Property(e => e.BuildingNumber).IsRequired().HasMaxLength(10);
                entity.Property(e => e.FlatNumber).IsRequired();
            });

            modelBuilder.Entity<GovernateCount>(entity =>
            {
                entity.HasKey(e => e.Governate);
                entity.Property(e => e.UserCount).IsRequired();
            });

            modelBuilder.Entity<GovernateEntity>().HasData(
                new GovernateEntity { Id = 1 , Governate = "Cairo" },
                new GovernateEntity { Id = 2, Governate = "Giza" },
                new GovernateEntity { Id = 3, Governate = "Alexandria" },
                new GovernateEntity { Id = 4, Governate = "Sharqya" },
                new GovernateEntity { Id = 5, Governate = "Dakhalia"  ,}
                );
            modelBuilder.Entity<CityEntity>().HasData(
                new CityEntity { Id = 1, City = "Cairo" , GovernateId = 1},
                new CityEntity { Id = 2, City = "Giza" , GovernateId = 2 },
                new CityEntity { Id = 6, City = "6 October" , GovernateId = 2 },
                new CityEntity { Id = 3, City = "Alexandria" , GovernateId = 3 },
                new CityEntity { Id = 4, City = "Mansoura" , GovernateId = 5},
                new CityEntity { Id = 5, City = "Zagazig" , GovernateId = 4}
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
