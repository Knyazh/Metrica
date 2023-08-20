using Microsoft.AspNetCore.Mvc;

namespace Metrica1.Controllers.Admin
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
