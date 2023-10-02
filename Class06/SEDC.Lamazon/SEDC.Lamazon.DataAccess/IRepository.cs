using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);

    }
}
