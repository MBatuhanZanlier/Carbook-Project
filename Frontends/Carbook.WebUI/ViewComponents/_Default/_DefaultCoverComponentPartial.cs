using Carbook.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents._Default
{
    public class _DefaultCoverComponentPartial:ViewComponent
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCoverComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var client=_httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7189/api/Banners"); 
            if(responsemessage.IsSuccessStatusCode)
            {
                var jsondata=await responsemessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
