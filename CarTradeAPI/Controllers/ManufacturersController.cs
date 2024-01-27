using CarTradeAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarTradeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturersController : ControllerBase
    {
        private readonly ILogger<CarsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly CarsRepository _carsRepository;

        public ManufacturersController(ILogger<CarsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _carsRepository = new CarsRepository(configuration);
        }

        [HttpGet(Name = "GetManufacturers")]
        public async Task<IEnumerable<string>> GetManufacturers()
        {
            var manufacturers = await _carsRepository.GetManufacturers();
            return manufacturers.Select(m => m.ManufacturerName);
        }
    }
}