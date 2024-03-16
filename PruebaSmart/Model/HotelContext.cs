using Microsoft.EntityFrameworkCore;

namespace PruebaSmart.Model
{
    public class HotelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("hoteles");
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Huesped> Huespedes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
