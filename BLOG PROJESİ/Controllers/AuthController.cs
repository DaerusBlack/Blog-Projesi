using BLOG_PROJESİ.GenericRepostorypattern.İntRep;
using BLOG_PROJESİ.Models.Entites.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BLOG_PROJESİ.Controllers
{
    public class AuthController : Controller
    {
        private readonly IGenericRep<User> _genericRep;
        public AuthController(IGenericRep<User> genericRep)
        { _genericRep = genericRep; }
        public IActionResult Login(string yonlen)
        {
            ViewBag.yonlen = yonlen;
            return View();


        }
        [HttpGet]
        public IActionResult Login(User userDto, string yonlen)
        {
            if (ModelState.IsValid)
            {
                User response = _genericRep.GetDefault(x => x.Username == userDto.Username && x.Password == userDto.Password);
                if (response == null)
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı yok");
                    return View();
                }
                HttpContext.Session.SetString("userId", response.Id.ToString());
                HttpContext.Session.SetString("Username", response.Username);
                if (string.IsNullOrEmpty(yonlen))
                { return RedirectToAction("List", "Article"); }
                return Redirect(yonlen); // Url yönlendirmelerinde Kullanılan İactionresult dönüşü
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User userDto)
        {
            if (ModelState.IsValid)
            {
                User userCheck = _genericRep.Where(x => x.Username == userDto.Username).FirstOrDefault();
                if (userCheck != null) return View();
                        _genericRep.Add(userDto);
                return RedirectToAction("Login");

            }
            return View();


        }
        public IActionResult LogOut()
        { HttpContext.Session.Remove("userId)");
            return RedirectToAction("Login", "Auth");
                }
    }
}
