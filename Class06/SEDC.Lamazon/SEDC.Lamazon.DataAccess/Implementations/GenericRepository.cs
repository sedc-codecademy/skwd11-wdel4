using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        
        protected readonly LamazonDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(LamazonDbContext dbContext)
        {    
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        virtual public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        virtual public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(e => e.Id == id);
        }

        virtual public int Insert(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        virtual public void Update(T entity)
        {

            _dbSet.Update(entity);
            _dbContext.SaveChanges();

            //var existingEntity = _entitites.FirstOrDefault(e => e.Id == entity.Id);
            //if(existingEntity != null)
            //{
            //    // Get entity type
            //    var entityType = typeof(T);
            //    // Get all properyies of passed type
            //    var properties = entityType.GetProperties();

            //    foreach(var property in properties)
            //    {
            //        //Get the new value from the updated entity
            //        var newValue = property.GetValue(entity);
            //        // update the value for the current propery in the loop
            //        property.SetValue(existingEntity, newValue);
            //    }
            //}
        }
        virtual public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        virtual public void DeleteById(int id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Id == id);
            if(entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
        }

     
    }
}
