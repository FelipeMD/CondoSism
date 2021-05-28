using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Domain.Apartamentos;
using WebApplication1.Domain.Apartamentos.Interfaces;
using WebApplication1.Domain.Context;

namespace WebApplication1.Infrastructure.Repository
{
    public class ApartamentoRepository : IApartamentoRepository
    {
        private MySqlContext _context;
        public ApartamentoRepository(MySqlContext context)
        {
            _context = context;
        }
        
        public Apartamento Create(Apartamento apartamento)
        {
            try
            {
                _context.Add(apartamento);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return apartamento;
        }

        public Apartamento FindById(long id)
        {
            return _context.Apartamentos.SingleOrDefault(m => m.Id.Equals(id));
        }
        
        public List<Apartamento> FindAll()
        {
            return _context.Apartamentos.ToList();
        }
        
        public Apartamento Update(Apartamento apartamento)
        {
            if (!Exists(apartamento.Id)) return new Apartamento();
            
            var result = _context.Apartamentos.SingleOrDefault(m => m.Id.Equals(apartamento.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(apartamento);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return apartamento;
        }

        public bool Exists(long id)
        {
            return _context.Apartamentos.Any(m => m.Id.Equals(id));
        }

        public void Delete(long id)
        {
            var result = _context.Apartamentos.SingleOrDefault(m => m.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Apartamentos.Remove(result);
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