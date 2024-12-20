using Carbook.Dto.CarDtos;
using Carbook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.Controllers
{
    public class CarController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Araçlacınızı Seçiniz";
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
        public async Task<IActionResult> CarDetail(int id)
        {
            
                ViewBag.v1 = "Araç Detayları";
                ViewBag.v2 = "Aracın Teknik Aksesuar ve Özellikleri";
                ViewBag.carid = id;
                return View();
            
        }
    }
}
