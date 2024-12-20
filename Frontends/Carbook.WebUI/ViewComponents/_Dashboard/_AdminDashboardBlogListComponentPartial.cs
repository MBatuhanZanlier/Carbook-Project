using Carbook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents._Dashboard
{
    public class _AdminDashboardBlogListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardBlogListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7189/api/Blogs/GetLast3BlogWithAuthors");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogByIdWithAuthorTake3Dto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

