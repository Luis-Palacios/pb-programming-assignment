using csv_import.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace csv_import.datalayer.Repositories
{
    public class EntityFrameworkRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {

        protected AccountManagerContext Db = null;

        protected DbSet<T> Table = null;

        public EntityFrameworkRepository()
        {
            Db = new AccountManagerContext();
            Table = Db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return Table.ToList();
        }

        public T Find(object id)
        {
            return Table.Find(id);
        }

        public void Insert(T obj)
        {
            Table.Add(obj);
        }

        public void Update(T obj)
        {
            Table.Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = Table.Find(id);
            Table.Remove(existing);
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Db != null)
                    Db.Dispose();
                Table = null;
            }
        }
    }
}