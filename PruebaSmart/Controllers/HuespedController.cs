using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaSmart.Model;
using PruebaSmart.Service;

namespace PruebaSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuespedController : ControllerBase
    {
        readonly HuespedService _service;

        public HuespedController(HuespedService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Huesped>> GetHuespedes()
        {
            return await _service.GetHuespedes();
        }

        [HttpGet("{Id}")]
        public async Task<Huesped> GetHuespedes(Guid Id)
        {
            return await _service.GetHuesped(Id);
        }

        [HttpPost]
        public async Task Create(Huesped huesped)
        {
            await _service.Create(huesped);
        }
    }
}
