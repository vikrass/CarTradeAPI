using Microsoft.Azure.Cosmos;

namespace CarTradeAPI
{
    public class CarsDBContext
    {
        public CarsDBContext(IConfiguration configuration) 
        {
            var cosmosdbConnectionString = configuration.GetSection("ConnectionStrings").GetSection("cosmosdbcontext").Value;

            var cosmosClient = new CosmosClient(cosmosdbConnectionString, new CosmosClientOptions());
            Database carsDbDatabase = cosmosClient.GetDatabase("carsdb");
            this.CarsContainer = carsDbDatabase.GetContainer("carsdata");
            this.CarBrandsContainer = carsDbDatabase.GetContainer("manufacturers");
            this.CarNamesContainer = carsDbDatabase.GetContainer("carNames");
        }

        public Container CarsContainer { get; private set; }

        public Container CarBrandsContainer { get; private set; }

        public Container CarNamesContainer { get; private set; }
    }
}
