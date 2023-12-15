using Rest_Contries.API.Model;
using System.Diagnostics.Metrics;

namespace Rest_Contries.API.Services.Interfaces
{
    public interface ICountries
    {
        public List<Country> GetData(string? name, string? currency, string? code, string? linguagem,  List<Country> result);
    }
}
