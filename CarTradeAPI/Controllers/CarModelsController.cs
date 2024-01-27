using CarTradeAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarTradeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarModelsController
    {
        private readonly ILogger<CarsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly CarsRepository _carsRepository;

        public CarModelsController(ILogger<CarsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _carsRepository = new CarsRepository(configuration);
        }

        [HttpGet(Name = "GetCarModels")]
        public async Task<IEnumerable<string>> GetCarModels([FromQuery(Name = "brandName")] string brandName)
        {
            var carModels = await _carsRepository.GetCarModels(brandName);
            return carModels.Select(carModel => carModel.CarName);
        }
    }
}
