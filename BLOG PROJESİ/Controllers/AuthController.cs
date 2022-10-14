using Microsoft.AspNetCore.Mvc;

namespace BLOG_PROJESİ.Controllers
{
    public class AuthControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
