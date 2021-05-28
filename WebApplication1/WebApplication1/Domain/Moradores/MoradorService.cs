using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            return morador;
        }

        public Morador FindById(long id)
        {
            return new Morador
            {
                Id = 1,
                PrimeiroNome = "Felipe",
                Sobrenome = "Souza",
                DataNasciment = new DateTime(05/04/1995),
                Telefone = "99999999",
                Cpf = "04714760130",
                Email = "fm.cab@live.com"
            };
        }
        
        public List<Morador> FindAll()
        {
            return _context.Moradores.ToList();
        }
        
        public Morador Update(Morador morador)
        {
            return morador;
        }
        
        public void Delete(long id)
        {
            //TODO: implementar delete
        }
    }
}