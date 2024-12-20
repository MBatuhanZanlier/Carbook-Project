using Carbook.Dto.BlogDtos;
using Carbook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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


        [HttpPost] 
        public async Task<IActionResult> AddCommentByBlog(CreateCommentDto comment)
        {
            var client= _httpClientFactory.CreateClient();   
            var jsondata=JsonConvert.SerializeObject(comment); 
            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responsemessage = await client.PostAsync("https://localhost:7189/api/Comments/AddComment", content); 
            if(responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
