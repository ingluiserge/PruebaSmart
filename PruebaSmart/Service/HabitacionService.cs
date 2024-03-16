using Microsoft.EntityFrameworkCore;
using PruebaSmart.Model;

namespace PruebaSmart.Service
{
    public class HabitacionService
    {
        readonly HotelContext _hotelContext;
        public HabitacionService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        public async Task Create(Habitacion habitacion)
        {
            _hotelContext.Habitaciones.Add(habitacion);
            await _hotelContext.SaveChangesAsync();
        }
        public async Task Update(Guid habitacionId, Habitacion NewDataHabitacion)
        {
            var habitacion = await _hotelContext.Habitaciones.FindAsync(habitacionId);            
            if (habitacion == null) throw new Exception("habitacion no encontrada!!");

            habitacion.Description = NewDataHabitacion.Description;
            habitacion.Ubicacion = NewDataHabitacion.Ubicacion;
            habitacion.Tax = NewDataHabitacion.Tax;
            habitacion.Base = NewDataHabitacion.Base;
            
            await _hotelContext.SaveChangesAsync();
        }

        public async Task<List<Habitacion>> GetAllHabitaciones()
        {
            return await _hotelContext.Habitaciones.ToListAsync();
        }

        public async Task<List<Habitacion>> GetAllHabitacionesByHotel(Guid id)
        {
            return await _hotelContext.Habitaciones.Where(w => w.Hotel.Id == id).ToListAsync();
        }

        public async Task Assign(Guid hotelId, Guid habitacionId)
        {
            var habitacion = await _hotelContext.Habitaciones.FindAsync(habitacionId);
            //var hotel = await _hotelContext.Hotel.FindAsync(hotelId);

            if (habitacion == null) throw new Exception("habitacion no encontrada!!");

            habitacion.HotelId = hotelId;

            _hotelContext.Habitaciones.Add(habitacion);
            await _hotelContext.SaveChangesAsync();
        }

        public async Task<bool> SwitchHabitacion(Guid HabitacionId)
        {
            var habitacion = await _hotelContext.Habitaciones.FindAsync(HabitacionId);
            if (habitacion == null) throw new Exception("hotel no encontrado");

            habitacion.Enable = !habitacion.Enable;

            await _hotelContext.SaveChangesAsync();

            return habitacion.Enable;
        }

        public async Task<int> GetHuespedesTotal(DateTime startDate, DateTime endDate)
        {
            return await _hotelContext
                .Habitaciones
                .Where(w => w.Reservas.Any(r => r.StartDate >= startDate && r.EndDate >= endDate))
                .CountAsync();
        }
    }
}
