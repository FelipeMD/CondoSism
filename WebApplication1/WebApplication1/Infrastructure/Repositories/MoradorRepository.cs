using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication1.Domain.Context;
using WebApplication1.Domain.Moradores;
using WebApplication1.Domain.Moradores.Interfaces;
using System.Linq;

namespace WebApplication1.Infrastructure.Repositories
{
    public class MoradorRepository : GenericRepository<Morador>, IMoradorRepository
    {
        public MoradorRepository(MySqlContext context) : base(context)
        {
            
        }

        public Morador Disable(long id)
        {
            if (!_context.Moradores.Any(m => m.Id.Equals(id))) return null;
            var user = _context.Moradores.SingleOrDefault(m => m.Id.Equals(id));
            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return user;
        }

        public List<Morador> FindByName(string firstName, string secondName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(secondName))
            {
                return _context.Moradores.Where(
                    m => m.PrimeiroNome.Contains(firstName)
                         && m.Sobrenome.Contains(secondName)).ToList();
            }
            else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(secondName))
            {
                return _context.Moradores.Where(
                    m => m.Sobrenome.Contains(secondName)).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(secondName))
            {
                return _context.Moradores.Where(
                    m => m.PrimeiroNome.Contains(firstName)).ToList();
            }

            return null;
        }
    }
}