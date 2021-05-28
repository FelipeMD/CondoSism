using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Domain.Context;
using WebApplication1.Domain.Moradores;
using WebApplication1.Domain.Moradores.Interfaces;

namespace WebApplication1.Infrastructure.Repository
{
    public class MoradorRepository : IMoradorRepository
    {
        private MySqlContext _context;
        public MoradorRepository(MySqlContext context)
        {
            _context = context;
        }
        
        public Morador Create(Morador morador)
        {
            try
            {
                _context.Add(morador);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return morador;
        }

        public Morador FindById(long id)
        {
            return _context.Moradores.SingleOrDefault(m => m.Id.Equals(id));
        }
        
        public List<Morador> FindAll()
        {
            return _context.Moradores.ToList();
        }
        
        public Morador Update(Morador morador)
        {
            if (!Exists(morador.Id)) return null;
            
            var result = _context.Moradores.SingleOrDefault(m => m.Id.Equals(morador.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(morador);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return morador;
        }

        public bool Exists(long id)
        {
            return _context.Moradores.Any(m => m.Id.Equals(id));
        }

        public void Delete(long id)
        {
            var result = _context.Moradores.SingleOrDefault(m => m.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Moradores.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}