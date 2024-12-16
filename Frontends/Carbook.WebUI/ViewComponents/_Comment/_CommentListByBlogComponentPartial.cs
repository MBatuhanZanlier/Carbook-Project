using Carbook.Dto.BlogDtos;
using Carbook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.ViewComponents._Comment
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7189/api/Blogs/GetLast3BlogWithAuthors");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
