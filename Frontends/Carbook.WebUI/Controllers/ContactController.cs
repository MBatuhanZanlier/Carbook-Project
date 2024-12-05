using Carbook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Carbook.WebUI.Controllers
{
    public class ContactController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        { 

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto contactDto)
        { 
            var client=_httpClientFactory.CreateClient(); 
            contactDto.SendDate=DateTime.Now;
            var jsondata = JsonConvert.SerializeObject(contactDto);
            StringContent stringContent=new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responsemessage = await client.PostAsync("https://localhost:7189/api/Contacts",stringContent); 
            if(responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
