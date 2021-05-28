using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.VisualBasic;
using WebApplication1.Domain.Context;
using WebApplication1.Domain.Moradores.Interfaces;
using WebApplication1.Domain.ValueObjetcs;

namespace WebApplication1.Domain.Moradores
{
    public class MoradorService : IMoradorService
    {
        private MySqlContext _context;
        public MoradorService(MySqlContext context)
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
            if (!Exists(morador.Id)) return new Morador();
            
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

        private bool Exists(long id)
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