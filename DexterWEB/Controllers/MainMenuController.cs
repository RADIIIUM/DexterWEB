using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace DexterWEB.Controllers
{
    public class MainMenuController : Controller
    {
        public IActionResult MainMenu()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            return View("~Views/Home/UserProfile");
        }

        public IActionResult ShopMenu()
        {
            return View("~Views/Home/ShopMenu");
        }
    }
}
