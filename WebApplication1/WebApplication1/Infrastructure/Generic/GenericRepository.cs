using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Base;
using WebApplication1.Domain.Context;

namespace WebApplication1.Infrastructure.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;

        private DbSet<T> _dataset;
        
        public GenericRepository(MySqlContext context, DbSet<T> dataset)
        {
            _context = context;
            _dataset = dataset;
        }
        
        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(m => m.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T Update(T item)
        {
            var result = _dataset.SingleOrDefault(m => m.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                
                return result;
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(m => m.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Moradores.Any(m => m.Id.Equals(id));
        }

    }
}