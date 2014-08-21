using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteDisksNET.Models
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IList<T> GetAll();
        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
    // The reposity patterns are intended to create an abstraction layer between data access layer and business logic layer
    // When the controller runs under a web server, it receives a repository that works with Entity Framework
    // When the controller runs under a unit test class, it receives a repository taht works with data stored in a way that you can easliy manipulate for testing, such as in-memory collection.
}
    
