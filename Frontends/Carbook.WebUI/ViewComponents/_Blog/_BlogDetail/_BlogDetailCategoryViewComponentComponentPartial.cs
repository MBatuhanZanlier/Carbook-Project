using Carbook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents._Blog._BlogDetail
{
    public class _BlogDetailCategoryViewComponentComponentPartial:ViewComponent
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailCategoryViewComponentComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()  
        {   
            var client=_httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7189/api/Categories"); 
            if(responsemessage.IsSuccessStatusCode)
            {
                var jsondata=await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata); 
                return View(values);
            }
            return View();  
        
        }
    }
}
