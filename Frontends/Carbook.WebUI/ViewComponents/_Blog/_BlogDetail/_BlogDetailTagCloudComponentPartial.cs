using Carbook.Dto.BlogDtos;
using Carbook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Carbook.WebUI.ViewComponents._Blog._BlogDetail
{
    public class _BlogDetailTagCloudComponentPartial:ViewComponent 
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7189/api/TagClouds/GetTagCloudByBlogId?id={id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetByBlogIdTagCloudDto>>(jsondata);
                return View(values);

            }
            return View();
        }
    }
}
