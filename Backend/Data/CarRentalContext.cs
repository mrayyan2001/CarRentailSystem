using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Data
{
    public class CarRentalContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options) { }

    }

}
