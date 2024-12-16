using Carbook.Dto.FooterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Carbook.WebUI.ViewComponents.UILayout
{
    public class _UILaoyutFooterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILaoyutFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7189/api/Footers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
