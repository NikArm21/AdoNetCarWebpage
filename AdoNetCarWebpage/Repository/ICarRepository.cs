using AdoNetCarWebpage.Models;

namespace AdoNetCarWebpage.Repository
{
    public interface ICarRepository
    {
        public Task<List<Car>> GetCars();
        public Task<Car> GetCarById(int carId);
        public Task<int> Create(Car car);
        public Task<int> Update(Car car);
        public Task<int> Delete(int carId);

    }
}
