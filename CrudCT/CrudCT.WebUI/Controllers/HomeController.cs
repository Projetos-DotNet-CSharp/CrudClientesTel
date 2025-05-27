using Microsoft.AspNetCore.Mvc;

namespace CrudCT.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
