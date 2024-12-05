﻿using Carbook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents._Blog
{
    public class _BlogLast3BlogWithAuthorsComponentPartial:ViewComponent
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogLast3BlogWithAuthorsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {  
            var client=_httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7189/api/Blogs/GetLast3BlogWithAuthors"); 
            if(responsemessage.IsSuccessStatusCode)
            {
                var jsondata=await responsemessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultLast3BlogWithAuthorsDto>>(jsondata); 
                return View(values);
            }
            return View(); 
        }
    }
}