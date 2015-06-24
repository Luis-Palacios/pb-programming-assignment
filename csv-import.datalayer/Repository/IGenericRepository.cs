using csv_import.domain;
using System;
using System.Collections.Generic;

namespace csv_import.datalayer.Repositories
{
    public interface IGenericRepository<T>: IDisposable where T:BaseEntity
    {

        IEnumerable<T> SelectAll();

        T Find(object id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);

        void Save(); 
    }
}
