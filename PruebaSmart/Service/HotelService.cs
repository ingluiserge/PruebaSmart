using Microsoft.EntityFrameworkCore;
using PruebaSmart.Controllers;
using PruebaSmart.Model;

namespace PruebaSmart.Service
{
    public class HotelService
    {
        readonly HotelContext _hotelContext;

        public HotelService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
     
        public async Task<List<Hotel>> GetHotels()
        {
            return await _hotelContext.Hotel.ToListAsync();
        }

        public async Task Create(Hotel hotel)
        {
            _hotelContext.Hotel.Add(hotel);
            await _hotelContext.SaveChangesAsync();
        }

        public async Task<bool> SwitchHotel(Guid HotelId)
        {
            var hotel = await _hotelContext.Hotel.FindAsync(HotelId);
            if (hotel == null) throw new Exception("hotel no encontrado");

            hotel.Enable = !hotel.Enable;

            await _hotelContext.SaveChangesAsync();

            return hotel.Enable;
        }
    }
}
