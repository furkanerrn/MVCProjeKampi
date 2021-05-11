using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IRepository<T> 
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T,bool>> filter);

        List<T> List();

        List<T> List(Expression<Func<T, bool>> filter);
    }
}
