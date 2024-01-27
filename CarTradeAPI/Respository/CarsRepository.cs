using Microsoft.Azure.Cosmos;

namespace CarTradeAPI.Repository
{
    public class CarsRepository
    {
        private readonly Container carContainer;
        private readonly Container manufacturerContainer;
        private readonly Container carModelsContainer;

        public CarsRepository(IConfiguration configuration)
        {
            var carscontext = new CarsDBContext(configuration);
            carContainer = carscontext.CarsContainer;
            manufacturerContainer = carscontext.CarBrandsContainer;
            carModelsContainer = carscontext.CarNamesContainer;
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

        public async Task<IEnumerable<CarModel>> GetCarModels(string carBrand)
        {
            var sqlQueryText = $"SELECT c.carName FROM c WHERE c.manufacturerName = \"{carBrand}\"";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<CarModel> queryResultSetIterator = this.carModelsContainer.GetItemQueryIterator<CarModel>(queryDefinition);
            List<CarModel> carModels = new List<CarModel>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<CarModel> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (CarModel carModel in currentResultSet)
                {
                    carModels.Add(carModel);
                }
            }
            return carModels;
        }
    }
}
