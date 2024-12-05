using Carbook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace Carbook.WebUI.ViewComponents._Blog._BlogDetail
{
    public class _BlogDetailMainComponentPartial:ViewComponent
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        { 
            var client=_httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7189/api/Blogs/{id}"); 
            if(responsemessage.IsSuccessStatusCode)  
            {  
               var jsondata=await responsemessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<GetBlogById>(jsondata);
                return View(values);
            
            }
            return View();
        }
    }
}
