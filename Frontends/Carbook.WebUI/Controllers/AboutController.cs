using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.Controllers
{
    public class AboutController : Controller
    { 
        
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımızda"; 
            ViewBag.v2 = "Bizi Tanıyın"; 
            return View();
        }
    }
}
