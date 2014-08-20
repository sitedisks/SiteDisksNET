using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Entity;
using System.Data;

namespace SiteDisksNET.Models
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private DbContext _context { get; set; }
          
        // DbContext is EF
        // DataContext is Linq2SQL

        public Repository(DbContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            } this._context = dataContext;
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList<T>();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                _context.Set<T>().Add(entity);
                this.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            if (entity == null)
            {

            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                _context.Entry(entity).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        //IDisposable impleyment
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }

    }


}