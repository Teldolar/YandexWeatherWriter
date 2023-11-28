using System.Data.SqlClient;
using Newtonsoft.Json;
using ConsoleApp1.Services;
using ConsoleApp1.Models;
using System.Timers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            dynamic? settings;

            using (StreamReader reader = new StreamReader("appsettings.json"))
            {
                settings = JsonConvert.DeserializeObject(reader.ReadToEnd());
            }

            string connectionString = settings!["ConnectionString"];
            string baseUrl = settings!["BaseUrl"];
            string location = settings!["Location"];
            string apiKey = settings!["ApiKey"];

            HttpService httpService = new(baseUrl, apiKey);
            DBService dbService = new(connectionString);

            int interval = settings!["Interval"];

            while (true)
            {
                string lat = string.Empty;
                string lon = string.Empty;

                switch (location)
                {
                    case "Moscow":
                        lat = "55.7522";
                        lon = "37.6156";
                        break;
                    case "Kazan":
                        lat = "55.7887";
                        lon = "49.1221";
                        break;
                    case "Sochi":
                        lat = "43.5992";
                        lon = "39.7257";
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор");
                        break;
                }

                WeatherInfoModel result = httpService.GetData<WeatherInfoModelRoot>($"forecast?lat={lat}&lon={lon}&extra=true&lang=ru_RU").GetAwaiter().GetResult().Fact;
                Console.Clear();
                await dbService.SaveWeatherDataToDatabase(result, location);
                Console.WriteLine($"Погода в {location} {DateTime.Now}:");
                Console.WriteLine("Температура: " + result.Temp);
                Console.WriteLine("Ощущается: " + result.FeelsLike);
                Console.WriteLine("Погода: " + result.Condition);
                Console.WriteLine("Скорость ветра: " + result.WindSpeed);
                Console.WriteLine("Скорость порывов: " + result.WindGust);
                Console.WriteLine("Влажность: " + result.Humidity);
                Console.WriteLine("Давление (в мм рт. ст.): " + result.PressureMm);
                Console.WriteLine("Давление (в гектопаскалях): " + result.PressurePa);
                Console.WriteLine("Тип осадков: " + result.PrecipitationType);
                await Task.Delay(interval);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка:" + ex);
            Console.ReadLine();
        }
    }
}