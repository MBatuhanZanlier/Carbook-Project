using Carbook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Carbook.WebUI.Controllers
{
    public class RentACarListController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IActionResult> Index(int LocationID)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7189/api/RentACar?LocationID={LocationID}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
