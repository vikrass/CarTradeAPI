using Microsoft.Azure.Cosmos;
using System.Collections;

namespace CarTradeAPI.Repository
{
    public class CarsRepository
    {
        private Container container;

        public CarsRepository(IConfiguration configuration)
        {
            var carscontext = new CarsDBContext(configuration);
            container = carscontext.CarsContainer;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
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
