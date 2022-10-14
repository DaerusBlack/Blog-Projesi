using BLOG_PROJESİ.Context;
using BLOG_PROJESİ.GenericRepostorypattern.İntRep;
using BLOG_PROJESİ.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLOG_PROJESİ.GenericRepostorypattern.BaseRep
{
    public class BaseRep<TEntity> : IGenericRep<TEntity> where TEntity : BaseEntity

    {

        private readonly AppDbContext _context;

        public BaseRep(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            entity.Status = Status.Passive;
            entity.DeleteDate = DateTime.Now;
            await SaveChanges();
        }

        public TEntity Find(int İd)
        {
            return _context.Set<TEntity>().Find(İd);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList(); 
        }

        public TEntity GetDefault(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().FirstOrDefault(expression);
         
        }

        public async Task Uptade(TEntity entity)
        {
           _context.Set<TEntity>().Update(entity);
            await SaveChanges();
        }

        public List<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression).ToList(); 
        }
    }
}
