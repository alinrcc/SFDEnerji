using Microsoft.EntityFrameworkCore;
using SFDEnerji.Data;
using SFDEnerji.Models;
using SFDEnerji.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SFDEnerji.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
      private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
          //  _context.Set<T>().Add(entity);
          _dbSet.Add(entity);
        
        }

        public void Delete(T entity)
        {
          entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        public void DeleteById(int id)
        {
            T entity = _dbSet.Find(id);
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        public IQueryable<T> GetAll()
        {
           return _dbSet.Where(x => x.IsDeleted == false);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
          //  return _dbSet.Where(filter).Where(x => x.IsDeleted == false);
          return GetAll().Where(filter);
        }

        public T GetById(int id)
        {
          return _dbSet.Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
           return _dbSet.Where(x=>x.IsDeleted==false).FirstOrDefault(filter);
        }

       

        public void Update(T entity)
        {
            entity.ModifiedDate= DateTime.Now;
           _dbSet.Update(entity);
        }
    }
}
