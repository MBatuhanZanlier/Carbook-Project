using Carbook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.Controllers
{
    public class BlogsController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public  async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Blog"; 
            ViewBag.v2 = "Bloglarımız";

            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7189/api/Blogs/GetAllBlogsWithAuthor"); 
            if(responsemessage.IsSuccessStatusCode)
            {
                var jsondata=await responsemessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthorAndCategory>>(jsondata);
                return View(values);
            }
            return View();
        } 
        public IActionResult BlogDetails(int BlogId,int AuthorID)
        { 
            ViewBag.blogid= BlogId;  
            ViewBag.authorid= AuthorID; 
            //ViewBag.authorId= authorid;
            return View();
        }
    }
}
