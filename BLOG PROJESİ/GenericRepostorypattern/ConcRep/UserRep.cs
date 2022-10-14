using BLOG_PROJESİ.Context;
using BLOG_PROJESİ.GenericRepostorypattern.BaseRep;
using BLOG_PROJESİ.Models.Entites.Concrete;

namespace BLOG_PROJESİ.GenericRepostorypattern.ConcRep
{
    public class UserRep:BaseRep<User>
    {public UserRep(AppDbContext context) : base
    (context)
        { }
        }
}
