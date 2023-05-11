using Microsoft.AspNetCore.Mvc;

namespace DexterWEB.Controllers
{
    public class MainMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
