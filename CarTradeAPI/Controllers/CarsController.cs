using CarTradeAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace CarTradeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        //// The Azure Cosmos DB endpoint for running this sample.
        //private static readonly string EndpointUri = "";

        //// The primary key for the Azure Cosmos account.
        //private static readonly string PrimaryKey = "";

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        private readonly ILogger<CarsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly CarsRepository _carsRepository;

        public CarsController(ILogger<CarsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _carsRepository = new CarsRepository(configuration);
        }

        [HttpGet(Name = "GetCars")]
        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _carsRepository.GetCars();
        }
    }
}