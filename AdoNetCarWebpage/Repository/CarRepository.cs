using AdoNetCarWebpage.Models;
using System.Data.SqlClient;

namespace AdoNetCarWebpage.Repository
{
    public class CarRepository : ICarRepository
    {
        public async Task<List<Car>> GetCars()
        {
            List<Car>  list = new List<Car>();   
            string connectionString = @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=GarageDB;Integrated Security=True";

            string sqlExpression = "SELECT * FROM Car";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows) // если есть данные
                {
                  

                    while (reader.Read()) // построчно считываем данные
                    {
                        Car car = new Car();
                        car.Id = (int)reader.GetValue(reader.GetOrdinal("Id"));
                        car.Brand =(string) reader.GetValue(reader.GetOrdinal("Brand"));
                        car.Model = (string)reader.GetValue(reader.GetOrdinal("Model"));
                        car.Year = (int)reader.GetValue(reader.GetOrdinal("Year"));
                        car.HorsePower = (int)reader.GetValue(reader.GetOrdinal("HorsePower"));
                        car.Price = (decimal)reader.GetValue(reader.GetOrdinal("Price"));
                        list.Add(car);
                    }
                }

                reader.Close();
            }
            return list;

        }
        public async Task<int> Delete(int carId)
        {
            string connectionString = @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=GarageDB;Integrated Security=True";
            string sqlExpression = $"DELETE FROM Car WHERE (Id={carId})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Добавлено объектов: {0}", number);
                return number;
            }

            return 0;
        }
        public async Task<int> Create(Car car)
        {
            string connectionString = @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=GarageDB;Integrated Security=True";
            string sqlExpression = $"INSERT INTO Car (Brand,Model,Year, HorsePower,Price) VALUES ('{car.Brand}','{car.Model}',{car.Year},{car.HorsePower},{car.Price})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Добавлено объектов: {0}", number);
                return number;
            }

            return 0;
        }

       

        public async Task<Car> GetCarById(int carId)
        {

            Car car=new Car();
            string connectionString = @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=GarageDB;Integrated Security=True";

                string sqlExpression = "SELECT * FROM Car where Id= @carId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@carId", carId);
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows) // если есть данные
                    {


                        while (reader.Read()) // построчно считываем данные
                        {
                      
                            car.Id = (int)reader.GetValue(reader.GetOrdinal("Id"));
                            car.Brand = (string)reader.GetValue(reader.GetOrdinal("Brand"));
                            car.Model = (string)reader.GetValue(reader.GetOrdinal("Model"));
                            car.Year = (int)reader.GetValue(reader.GetOrdinal("Year"));
                            car.HorsePower = (int)reader.GetValue(reader.GetOrdinal("HorsePower"));
                            car.Price = (decimal)reader.GetValue(reader.GetOrdinal("Price"));
                         
                        }
                    }
                    else
                {
                    return null;
                }

                    reader.Close();
                }
                return car;

            
        }

       

        public async Task<int> Update(Car car)
        {
            string connectionString = @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=GarageDB;Integrated Security=True";
            string sqlExpression = $"UPDATE Car SET Brand='{car.Brand}',Model='{car.Model}',Year={car.Year},HorsePower={car.HorsePower},Price={car.Price} WHERE Id={car.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Добавлено объектов: {0}", number);
                return number;
            }

            return 0;
        }
    }
}
