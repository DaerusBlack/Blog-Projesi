using BLOG_PROJESİ.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLOG_PROJESİ.GenericRepostorypattern.İntRep
{
    public interface IGenericRep<T> where T : BaseEntity

    {
        List<T> GetAll();
        T Find(int İd);
        Task Add(T entity);
        Task Uptade(T entity);
        Task Delete(T entity);
        List<T> Where(Expression<Func<T, bool>> expression);
        T GetDefault(Expression<Func<T, bool>> expression);
    

    }
}
