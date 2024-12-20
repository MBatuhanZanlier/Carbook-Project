using Carbook.Dto.CarFeatureDtos;
using Carbook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Carbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7189/api/CarFeatures?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("Index/{id}")]
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatures)
        {
            foreach (var item in resultCarFeatures)
            {
                if(item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7189/api/CarFeatures/ChangeCarFeatureAvailableToTrue?id=" + item.CarFeatureId);
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7189/api/CarFeatures/ChangeCarFeatureAvailableToFalse?id=" + item.CarFeatureId);
                }
            }
            return RedirectToAction("Index", "AdminCar");

        }

        [Route("CreateFeatureByCarId")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7060/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
