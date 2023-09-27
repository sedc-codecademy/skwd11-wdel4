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
        protected List<T> _entitites;

        public GenericRepository(List<T> entities)
        {
            _entitites = entities;
        }

        virtual public List<T> GetAll()
        {
            return _entitites;
        }

        virtual public T GetById(int id)
        {
            return _entitites.FirstOrDefault(e => e.Id == id);
        }

        virtual public int Insert(T entity)
        {
           _entitites.Add(entity);
            return entity.Id;
        }

        virtual public void Update(T entity)
        {
            var existingEntity = _entitites.FirstOrDefault(e => e.Id == entity.Id);
            if(existingEntity != null)
            {
                // Get entity type
                var entityType = typeof(T);
                // Get all properyies of passed type
                var properties = entityType.GetProperties();

                foreach(var property in properties)
                {
                    //Get the new value from the updated entity
                    var newValue = property.GetValue(entity);
                    // update the value for the current propery in the loop
                    property.SetValue(existingEntity, newValue);
                }
            }
        }
        virtual public void DeleteById(int id)
        {
            var entity = _entitites.FirstOrDefault(e => e.Id == id);
            if(entity != null)
            {
                _entitites.Remove(entity);
            }
        }
    }
}
