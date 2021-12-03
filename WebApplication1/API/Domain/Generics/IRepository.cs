using System.Collections.Generic;
using API.Domain.Entities.Base;

namespace API.Domain.Generics
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
        
        List<T> FindWitchPagedSearch(string query);
        int GetCount(string query);
    }
}