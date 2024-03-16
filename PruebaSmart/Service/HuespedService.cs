using Microsoft.EntityFrameworkCore;
using PruebaSmart.Model;

namespace PruebaSmart.Service
{
    public class HuespedService
    {
        readonly HotelContext _hotelContext;
        public HuespedService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task Create(Huesped huesped)
        {
            _hotelContext.Huespedes.Add(huesped);
            await _hotelContext.SaveChangesAsync();
        }

        public async Task<List<Huesped>> GetHuespedes()
        {
            return await _hotelContext.Huespedes.ToListAsync();
        }

        public async Task<Huesped> GetHuesped(Guid HuspedId)
        {
            var huesped =  await _hotelContext.Huespedes.FindAsync(HuspedId);

            return huesped == null ? throw new Exception("huesped no encontrado") : huesped;
        }
    }
}
