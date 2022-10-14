using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BLOG_PROJESİ.Models
{
    public class ArticleCreateViewModel
    {
        [Required(ErrorMessage = "Boş Bırakmayınız")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Boş bırakmayınız")]
        public string Content { get; set; }
        [Display(Name = "Article Picture")]
        public IFormFile ArticlePicture { get; set; }

    }
}