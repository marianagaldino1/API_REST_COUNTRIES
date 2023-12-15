using Microsoft.AspNetCore.Mvc;
using Rest_Contries.API.Model;
using Rest_Contries.API.Services.Interfaces;
using System.Diagnostics.Metrics;

namespace Rest_Contries.API.Controllers
{
    public class CountriesController
    {
        private readonly ICountries _country;

        public CountriesController(ICountries country)
        {
            _country = country;
        }

        [HttpGet("GetCountry")]
        public List<Country> GeyCountry (string? name, string? currency, string? code, string? language)
        {
            List<Country> result = new List<Country>();
            result = _country.GetData(name, currency, code, language, result);

            return result;
        }

    }
}
