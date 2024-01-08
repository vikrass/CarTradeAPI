using Microsoft.Azure.Cosmos;

namespace CarTradeAPI
{
    public class CarsDBContext
    {
        public CarsDBContext(IConfiguration configuration) 
        {
            var cosmosdbConnectionString = configuration.GetSection("ConnectionStrings").GetSection("cosmosdbcontext").Value;

            var cosmosClient = new CosmosClient(cosmosdbConnectionString, new CosmosClientOptions());
            var database = cosmosClient.GetDatabase("carsdb");
            this.CarsContainer = database.GetContainer("carsdata");
        }

        public Container CarsContainer { get; private set; }
    }
}
