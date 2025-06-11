using Figura.SpeedwayRider.Model.DAO;
using Figura.SpeedwayRider.Service;
using Microsoft.AspNetCore.Mvc;

namespace Figura.SpeedwayRider.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RiderController : Controller
    {
        private readonly IRiderService _service;

        public RiderController(IRiderService service)
        {
            _service = service;
        }

        [HttpGet("AllRiders")]
        public async Task<List<Rider>> FetchAllRiders()
        {
            var res = await _service.GetAllRiders();

            return res;
        }

        [HttpPost("InitialRiders")]
        public async Task<List<Rider>> GetByInitials([FromBody] List<Rider> initials)
        {
            var res = await _service.FindByInititals(initials);

            return res;
        }

        [HttpPost]
        public async Task<Rider> AddRider([FromBody] Rider rider)
        {
            var res = await _service.AddRider(rider);

            return res;
        }
    }
}
