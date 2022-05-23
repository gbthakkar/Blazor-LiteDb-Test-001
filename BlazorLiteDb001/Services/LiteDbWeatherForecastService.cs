using BlazorLiteDb001.Data;
using BlazorLiteDb001.Model;
using LiteDB;

namespace BlazorLiteDb001.Services
{
    public interface ILiteDbWeatherForecastService
    {
        IEnumerable<WeatherForecast> FindAll();
        WeatherForecast? FindOne(int id);
        bool Insert(WeatherForecast forecast);
        bool Update(WeatherForecast forecast);
        bool Delete(int id);
    }

    public class LiteDbWeatherForecastService : ILiteDbWeatherForecastService
    {
        private LiteDatabase _liteDb;

        public LiteDbWeatherForecastService(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public IEnumerable<WeatherForecast> FindAll()
        {
            return _liteDb.GetCollection<WeatherForecast>("WeatherForecast")
                .FindAll();
        }
        public WeatherForecast? FindOne(int id)
        {
            return _liteDb.GetCollection<WeatherForecast>(MyEnums.Tables.WeatherForecast)
                .Find(x => x.Id == id).FirstOrDefault();
        }
        public bool Insert(WeatherForecast forecast)
        {
            return _liteDb.GetCollection<WeatherForecast>("Api")
                .Insert(forecast);
        }

        public bool Update(WeatherForecast forecast)
        {
            return _liteDb.GetCollection<WeatherForecast>("Api")
                .Update(forecast);
        }

        public bool Delete(int id)
        {
            return _liteDb.GetCollection<WeatherForecast>("Api")
                .Delete(id);
        }

    }
}
