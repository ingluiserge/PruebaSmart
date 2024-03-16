using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaSmart.Model;
using PruebaSmart.Request;
using PruebaSmart.Service;

namespace PruebaSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        readonly HabitacionService _habitacionService;

        public HabitacionController(HabitacionService habitacionService)
        {
            _habitacionService = habitacionService;
        }

        [HttpPost]
        public async Task Create(Habitacion habitacion) { 
            await _habitacionService.Create(habitacion);
        }

        [HttpPut]
        public async Task Update(Guid HabitacionId,Habitacion habitacion)
        {
            await _habitacionService.Create(habitacion);
        }

        [HttpGet]
        public async Task<List<Habitacion>> GetAllHabitaciones()
        {
            return await _habitacionService.GetAllHabitaciones();
        }

        [HttpGet("{Id}")]        
        public async Task<List<Habitacion>> GetAllHabitacionesByHotel(Guid Id)
        {
            return await _habitacionService.GetAllHabitacionesByHotel(Id);
        }

        [HttpPost("assign")]
        public async Task Assign(AssignHabitacionRequest request)
        {
            await _habitacionService.Assign(request.hotelId, request.habitacionId);
        }

        [HttpPatch("{HabitacionId}")]
        public async Task Switch(Guid habitacionId)
        {
            await _habitacionService.SwitchHabitacion(habitacionId);
        }
    }
}
