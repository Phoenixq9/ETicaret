using ETicaret.Business.GenericRepository.Interface;
using ETicaret.DataAccess.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.GenericRepository.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ETicaretDbContext db = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.db = new ETicaretDbContext();
            table = db.Set<T>();
        }
        public GenericRepository(ETicaretDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public void Delete(object id)
        {
            T delete = table.Find(id);
            table.Remove(delete);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {            
           return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}
