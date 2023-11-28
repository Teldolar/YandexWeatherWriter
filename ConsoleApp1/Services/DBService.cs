using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class DBService
    {
        private readonly SqlConnection _connection;

        public DBService(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public async Task SaveWeatherDataToDatabase(WeatherInfoModel weatherInfo, string location)
        {
            try
            {
                _connection.Open();
                string query = "INSERT INTO WeatherInfo " + 
                    "(Location, Temp, FeelsLike, Condition, WindSpeed, WindGust, Humidity, PressureMm, PressurePa, PrecType)" +
                    " VALUES (@Location, @Temp, @FeelsLike, @Condition, @WindSpeed, @WindGust, @Humidity, @PressureMm, @PressurePa, @PrecType)";

                SqlCommand command = new(query, _connection);
                command.Parameters.AddWithValue("@Location", location);
                command.Parameters.AddWithValue("@Temp", weatherInfo.Temp);
                command.Parameters.AddWithValue("@FeelsLike", weatherInfo.FeelsLike);
                command.Parameters.AddWithValue("@Condition", weatherInfo.Condition);
                command.Parameters.AddWithValue("@WindSpeed", weatherInfo.WindSpeed);
                command.Parameters.AddWithValue("@WindGust", weatherInfo.WindGust);
                command.Parameters.AddWithValue("@Humidity", weatherInfo.Humidity);
                command.Parameters.AddWithValue("@PressureMm", weatherInfo.PressureMm);
                command.Parameters.AddWithValue("@PressurePa", weatherInfo.PressurePa);
                command.Parameters.AddWithValue("@PrecType", weatherInfo.PrecipitationType);
                await command.ExecuteNonQueryAsync();
            }
            catch
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
