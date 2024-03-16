using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaSmart.Model;
using PruebaSmart.Service;

namespace PruebaSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        readonly HabitacionService _habitacioneService;
        readonly ReservaService _reservaService;

        public ReservaController(HabitacionService habitacioneService, ReservaService reservaService)
        {
            _habitacioneService = habitacioneService;
            _reservaService = reservaService;
        }

        [HttpPost]
        public async Task CreateReserva(Reserva reserva) {
            await _reservaService.Create(reserva);
        }

        [HttpGet()]
        public async Task<List<Reserva>> GetReservas()
        {
            return await _reservaService.GetReservas();
        }

        [HttpGet("{HotelId}")]
        public async Task<List<Reserva>> GetReservas(Guid HotelId)
        {
            return await _reservaService.GetReservas(HotelId);
        }

        [HttpGet("{starDate}/{endDate}")]
        public async Task<int> GetHuespedesTotal(DateTime startDate, DateTime endDate)
        {
            return await _habitacioneService.GetHuespedesTotal(startDate, endDate);
        }


    }
}
