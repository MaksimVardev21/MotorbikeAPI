using Microsoft.EntityFrameworkCore;
using MotorbikeAPI.Data;

namespace MotorbikeAPI.Data
{
    public class MotorbikeContext : DbContext
    {
        public DbSet<Motorbike> Motorbike { get; set; }
        public MotorbikeContext(DbContextOptions<MotorbikeContext> options)
        : base(options)
        {

        }
        public DbSet<MotorbikeAPI.Data.Rating>? Rating { get; set; }
        public DbSet<MotorbikeAPI.Data.RentalBooking>? RentalBooking { get; set; }
        public DbSet<MotorbikeAPI.Data.User>? User { get; set; }

    }
}
