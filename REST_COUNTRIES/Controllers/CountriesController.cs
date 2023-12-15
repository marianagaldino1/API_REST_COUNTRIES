using Microsoft.AspNetCore.Mvc;
using REST_COUNTRIES.Model;
using REST_COUNTRIES.Services.Interfaces;
using System.Diagnostics.Metrics;

namespace REST_COUNTRIES.Controllers
{
    public class CountriesController
    {
        private readonly ICountries _country;

        public CountriesController(ICountries country)
        {
            _country = country;
        }

        [HttpGet("GetCountry")]
        public List<Country> GeyCountry (string? name, string? currency, string? code)
        {
            List<Country> result = new List<Country>();
            result = _country.GetData(name, currency, code, result);

            return result;
        }
    }
}
