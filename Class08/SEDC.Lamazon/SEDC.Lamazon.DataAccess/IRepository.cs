using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null, string? inludeProperties  = null);
        T Get(Expression<Func<T, bool>>? filter = null, string? inludeProperties = null);
        int Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);

    }
}
