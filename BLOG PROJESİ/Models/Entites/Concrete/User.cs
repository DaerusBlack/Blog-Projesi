using BLOG_PROJESİ.Models.Abstract;
using System.Collections.Generic;

namespace BLOG_PROJESİ.Models.Entites.Concrete
{
    public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }        

        public List<Article> Articles { get; set; }
    }
}