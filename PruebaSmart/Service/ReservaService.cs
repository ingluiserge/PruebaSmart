using Microsoft.EntityFrameworkCore;
using PruebaSmart.Model;

namespace PruebaSmart.Service
{
    public class ReservaService
    {
        readonly HotelContext _hotelContext;
        public ReservaService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task Create(Reserva reserva)
        {
            _hotelContext.Reservas.Add(reserva);
            await _hotelContext.SaveChangesAsync();
        }

        public async Task<List<Reserva>> GetReservas() {
            return await _hotelContext.Reservas.ToListAsync();
        }

        public async Task<List<Reserva>> GetReservas(Guid HotelId) { 
            return await _hotelContext
                .Reservas
                .Where(w => w.Habitacion.Hotel.Id == HotelId)
                .ToListAsync();
        }        
    }
}
