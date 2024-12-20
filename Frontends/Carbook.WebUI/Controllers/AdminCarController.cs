using Carbook.Dto.BrandDtos;
using Carbook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Carbook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7189/api/Cars/GetCarWithBrand");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsondata);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7189/api/Brands");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsondata);
                List<SelectListItem> brandValues = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.BrandId.ToString()
                                                    }).ToList();

                ViewBag.brandValues = brandValues;
                return View();
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7189/api/Cars", stringContent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7189/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7189/api/Brands");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsondata);
                List<SelectListItem> brandValues = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.BrandId.ToString()
                                                    }).ToList();

                ViewBag.brandValues = brandValues;
              
            }
        
            var responseMessage1 = await client.GetAsync($"https://localhost:7189/api/Cars/{id}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsondata1 = await responseMessage1.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<UpdateCarDto>(jsondata1);
                return View(values2);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("https://localhost:7189/api/Cars", stringContent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet] 
        public async Task<IActionResult> AdminCarDetail()
        {
            return View();
        }
    }
}
