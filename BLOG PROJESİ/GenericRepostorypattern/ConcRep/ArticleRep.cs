using BLOG_PROJESİ.Context;
using BLOG_PROJESİ.GenericRepostorypattern.BaseRep;
using BLOG_PROJESİ.Models.Entites.Concrete;

namespace BLOG_PROJESİ.GenericRepostorypattern.ConcRep
{
    public class ArticleRep : BaseRep<Article>
    {
        public ArticleRep (AppDbContext context) : base(context) { }


    }
    
    
}
