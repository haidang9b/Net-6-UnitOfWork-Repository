using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
