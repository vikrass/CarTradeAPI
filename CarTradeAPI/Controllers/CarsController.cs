using Microsoft.AspNetCore.Mvc;

namespace CarTradeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {

        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCars")]
        public IEnumerable<Car> Get()
        {
            return new List<Car>() 
            {
                new Car("Maruti Suzuki", "Swift", "VXI", 1200, "Petrol", 2012, 2013, 410000),
                new Car("Honda", "City", "VX CVT", 1497, "Petrol", 2014, 2014, 625000),
                new Car("Hyundai", "Creta", "SX 1.4 Turbo 7 DCT", 1353, "Petrol", 2020, 2020, 1625000),
            };
        }
    }
}