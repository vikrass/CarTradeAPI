using Microsoft.Azure.Cosmos;
using System.Collections;

namespace CarTradeAPI.Repository
{
    public class CarsRepository
    {
        private Container carContainer;
        private Container manufacturerContainer;

        public CarsRepository(IConfiguration configuration)
        {
            var carscontext = new CarsDBContext(configuration);
            carContainer = carscontext.CarsContainer;
            manufacturerContainer = carscontext.CarBrandsContainer;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            var sqlQueryText = "SELECT * FROM c";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Car> queryResultSetIterator = this.carContainer.GetItemQueryIterator<Car>(queryDefinition);

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

        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            var sqlQueryText = "SELECT * FROM c";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Manufacturer> queryResultSetIterator = this.manufacturerContainer.GetItemQueryIterator<Manufacturer>(queryDefinition);
            List<Manufacturer> manufacturers = new List<Manufacturer>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Manufacturer> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Manufacturer manufacturer in currentResultSet)
                {
                    manufacturers.Add(manufacturer);
                }
            }
            return manufacturers;
        }
    }
}
