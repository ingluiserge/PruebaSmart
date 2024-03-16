using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaSmart.Model;
using PruebaSmart.Service;

namespace PruebaSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        readonly HotelService hotelService;

        public HotelController(HotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<List<Hotel>> getAll() {
            return await hotelService.GetHotels();
        }

        [HttpPost]
        public async Task createPost(Hotel hotel) { 
            await hotelService.Create(hotel);
        }
    }
}
