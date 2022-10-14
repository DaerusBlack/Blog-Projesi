using BLOG_PROJESİ.GenericRepostorypattern.İntRep;
using BLOG_PROJESİ.Models.Abstract;
using BLOG_PROJESİ.Models.Entites.Concrete;
using BLOG_PROJESİ.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOG_PROJESİ.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IWebHostEnvironment
            _webHostEnvironment;
        private readonly IGenericRep<Article>
            _genericRep;
        public ArticleController(IWebHostEnvironment webHostEnvironment, IGenericRep<Article> genericRep)
        {
            _webHostEnvironment = webHostEnvironment;
            _genericRep = genericRep;
        }
        public IActionResult List()
        {
            var list = _genericRep.Where(x => x.Status != Status.Passive);

            return View(list);

        }

        public IActionResult Create(string yonlen)
        {
            ViewBag.yonlen = yonlen;
            return View();
        }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ArticleCreateViewModel model, string yonlen)
    {
        if(ModelState.IsValid)
            {
            var article = new Article()
            {
                Title = model.Title,
                Content = model.Content,
                AuthorId = int.Parse(HttpContext.Session.GetString("userId")),
                ArticlePicture = model.ArticlePicture.GetUniqueNameAndSavePhotoToDisk(_webHostEnvironment)
            };
            _genericRepository.Add(article);
            TempData["message"] = "Article Created!";
            if (string.IsNullOrEmpty(yonlen))
            {
                return RedirectToAction("List");
            }
            return Redirect(yonlen);
        }
            else
            return View();
    }
}

