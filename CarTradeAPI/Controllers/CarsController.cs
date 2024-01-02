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

        public CarsController(ILogger<CarsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetCars")]
        public async Task<IEnumerable<Car>> Get()
        {
            var cosmosdbConnectionString = _configuration.GetSection("ConnectionStrings").GetSection("cosmosdbcontext").Value;

            this.cosmosClient = new CosmosClient(cosmosdbConnectionString, new CosmosClientOptions());
            this.database = cosmosClient.GetDatabase("carsdb");
            this.container = database.GetContainer("carsdata");

            var sqlQueryText = "SELECT * FROM c";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Car> queryResultSetIterator = this.container.GetItemQueryIterator<Car>(queryDefinition);

            List<Car> cars = new List<Car>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Car> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Car car in currentResultSet)
                {
                    cars.Add(car);
                }
            }

            return cars;
        }
    }
}