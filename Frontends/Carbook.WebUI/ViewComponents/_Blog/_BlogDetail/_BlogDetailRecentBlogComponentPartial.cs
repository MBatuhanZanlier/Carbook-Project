using Carbook.Dto.BlogDtos;
using Carbook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents._Blog._BlogDetail
{
    public class _BlogDetailRecentBlogComponentPartial:ViewComponent
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailRecentBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)  
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7189/api/Blogs/GetAllBlogWithAuthorsTake3?id={id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogByIdWithAuthorTake3Dto>>(jsondata); 
                return View(values);
            }
            return View();
        }
    }
}
