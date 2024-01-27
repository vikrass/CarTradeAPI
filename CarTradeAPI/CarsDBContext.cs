using Microsoft.Azure.Cosmos;

namespace CarTradeAPI
{
    public class CarsDBContext
    {
        public CarsDBContext(IConfiguration configuration) 
        {
            var cosmosdbConnectionString = configuration.GetSection("ConnectionStrings").GetSection("cosmosdbcontext").Value;

            var cosmosClient = new CosmosClient(cosmosdbConnectionString, new CosmosClientOptions());
            var carsDbDatabase = cosmosClient.GetDatabase("carsdb");
            this.CarsContainer = carsDbDatabase.GetContainer("carsdata");

            var manufacturersDbDatabase = cosmosClient.GetDatabase("manufacturers");
            this.CarBrandsContainer = manufacturersDbDatabase.GetContainer("manufacturers");

            var carNamesDatabase = cosmosClient.GetDatabase("carNames");
            this.CarNamesContainer = carNamesDatabase.GetContainer("carNames");
        }

        public Container CarsContainer { get; private set; }

        public Container CarBrandsContainer { get; private set; }

        public Container CarNamesContainer { get; private set; }
    }
}
