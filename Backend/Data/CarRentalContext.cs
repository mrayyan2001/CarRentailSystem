using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Data
{
    public class CarRentalContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-many relationship between User and Rentals
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.User)  // A rental belongs to one user
                .WithMany(u => u.Rentals)  // A user can have many rentals
                .HasForeignKey(r => r.UserId);

            // One-to-many relationship between Car and Rentals
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Car)  // A rental belongs to one car
                .WithMany(c => c.Rentals)  // A car can have many rentals
                .HasForeignKey(r => r.CarId);
        }
    }

}
