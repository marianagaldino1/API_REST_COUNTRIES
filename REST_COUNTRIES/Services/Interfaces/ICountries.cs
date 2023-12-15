using REST_COUNTRIES.Model;
using System.Diagnostics.Metrics;

namespace REST_COUNTRIES.Services.Interfaces
{
    public interface ICountries
    {
        public List<Country> GetData(string? name, string? currency, string? code, List<Country> result);
    }
}
