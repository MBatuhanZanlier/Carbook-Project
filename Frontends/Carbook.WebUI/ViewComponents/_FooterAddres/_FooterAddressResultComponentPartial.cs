using Carbook.Dto.CarDtos;
using Carbook.Dto.FooterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents._FooterAddres
{
    public class _FooterAddressResultComponentPartial:ViewComponent
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressResultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        } 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7189/api/Footers");  
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterDto>>(jsondata);
                return View(values);
            }
            return View();
        } 
    }
}
