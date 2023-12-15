using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rest_Contries.Web.Model;
using System.Net.Http;

namespace Rest_Contries.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CountryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            
                return View();
            
        }

        public async Task<IActionResult> GetConsulta(string name, string currency, string code, string language)
        {
            var client = _httpClientFactory.CreateClient("RestCountriesAPI");

            // Construir a URL com os parâmetros
            var apiUrl = $"/GetCountry?name={name}&currency={currency}&code={code}&language={language}";

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                // Processar os dados da resposta (exemplo de desserialização de JSON)
                var countryData = JsonConvert.DeserializeObject<List<Country>>(content);

                // Agora você pode manipular countryData conforme necessário, por exemplo, retorná-lo como JSON
                return Json(countryData);
            }
            else
            {
                // Lidar com a resposta de erro, se necessário
                return BadRequest("Erro ao obter dados da API");
            }
        }



    }
}
