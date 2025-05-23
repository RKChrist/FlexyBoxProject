using Microsoft.AspNetCore.Mvc;

namespace FlexyBoxProject.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
