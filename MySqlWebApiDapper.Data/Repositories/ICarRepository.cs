using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiMySQLNetCore.Models;

namespace WebApiMySQLNetCore.Data.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<CarModel>> GetAllCars();
        Task<CarModel> GetByIdCar(int idCar);
        Task<bool> InsertCar(CarModel item);
        Task<bool> UpdateByIdCar(CarModel item);
        Task<bool> DeleteCar(CarModel item);
    }
}