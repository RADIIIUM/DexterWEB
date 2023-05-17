using Microsoft.AspNetCore.Mvc;

namespace DexterWEB.Controllers
{
    public class ShopMenuController : Controller
    {
        public IActionResult ShopMenu()
        {
            return View();
        }
    }
}
