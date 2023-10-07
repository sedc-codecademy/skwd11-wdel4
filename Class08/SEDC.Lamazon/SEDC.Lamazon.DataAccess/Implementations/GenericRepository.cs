using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        //virtual public List<T> GetAll()
        //{
        //    return _dbSet.ToList();
        //}

        //virtual public T GetById(int id)
        //{
        //    return _dbSet.FirstOrDefault(e => e.Id == id);
        //}
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

        public List<T> GetAll(Expression<Func<T, bool>>? filter = null, string? inludeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (inludeProperties != null)
            {
                var inludes = inludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var inlude in inludes)
                {
                    var nestedProps = inlude.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    query = nestedProps.Length > 1 ? ApplyNestedInclude(query, nestedProps) : query.Include(inlude);
                }
            }

            return query.ToList();
        }

        public T Get(Expression<Func<T, bool>>? filter = null, string? inludeProperties = null)
        {
            // "User,Comapny.Emplyoe"

            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            if( inludeProperties != null)
            {
                var inludes = inludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var inlude in inludes)
                {
                    var nestedProps = inlude.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    query = nestedProps.Length > 1 ? ApplyNestedInclude(query, nestedProps) : query.Include(inlude);
                }
            }

            return query.FirstOrDefault();
        }

        private IQueryable<T> ApplyNestedInclude(IQueryable<T> query, string[] includeProperties, int index = 0)
        {
            if( index == includeProperties.Length - 1)
            {
                return query.Include(string.Join(".", includeProperties));
            }
            return ApplyNestedInclude(query.Include(string.Join('.', includeProperties.Take(index + 1))), includeProperties, index + 1);
        }
    }
}
