using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using WebApiMySQLNetCore.Models;

namespace WebApiMySQLNetCore.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private MySqlConfiguration _sqlConfiguration;

        public CarRepository(MySqlConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }

        protected MySqlConnection DbConnection()
        {
            return new MySqlConnection(_sqlConfiguration.ConectionString);
        }
 
        public async Task<IEnumerable<CarModel>> GetAllCars()
        {
            var db = DbConnection();
            var sql = @"SELECT idCar,model,color,year,doors FROM car";

            return await db.QueryAsync<CarModel>(sql, new { });
        }

        public async Task<CarModel> GetByIdCar(int idcar)
        {
            var dbCar = DbConnection();
            var sqlCar = @"SELECT idCar, model, color, year, doors FROM car WHERE idcar = @IdCar";

            return await dbCar.QueryFirstAsync<CarModel>(sqlCar, new { IdCar = idcar});
        }

        public async Task<bool> InsertCar(CarModel item)
        {
            var dbCar = DbConnection();
            var sqlCar = @"INSERT INTO car (model,color,year,doors) VALUES (@Model,@Color,@Year,@Doors)";

            var result = await dbCar.ExecuteAsync(sqlCar, new { item.Model, item.Color, item.Year, item.Doors });

            return result > 0;
        }

        public async Task<bool> UpdateByIdCar(CarModel item)
        {
            var dbCar = DbConnection();
            var sqlCar = @"UPDATE car SET model = @Model,color = @Color,year = @Year,doors = @Doors WHERE idcar = @IdCar";

            var result = await dbCar.ExecuteAsync(sqlCar, new { item.Model, item.Color, item.Year, item.Doors, item.IdCar });

            return result > 0;
        }

        public async Task<bool> DeleteCar(CarModel item)
        {
            var dbCar = DbConnection();
            var sqlCar = @"DELETE  FROM car WHERE idCar = @IdCar";

            var result = await dbCar.ExecuteAsync(sqlCar, new { idCar = item.IdCar});

            return result > 0;
        }
    }
}