using Microsoft.EntityFrameworkCore;
using MVCBlog.Models.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVCBlog.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly BlogDbContext _context;

        protected BaseRepository(BlogDbContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
