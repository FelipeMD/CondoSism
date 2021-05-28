using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualBasic;
using WebApplication1.Domain.Moradores.Interfaces;
using WebApplication1.Domain.ValueObjetcs;

namespace WebApplication1.Domain.Moradores
{
    public class MoradorService : IMoradorService
    {
        private volatile int count;
        
        public Morador Create(Morador morador)
        {
            return morador;
        }
        
        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Morador FindById(long id)
        {
            return new Morador
            {
                Id = IncrementAndGet(),
                PrimeiroNome = "Felipe",
                Sobrenome = "Souza",
                DataNasciment = new DateTime(05/04/1995),
                Telefone = "99999999",
                Cpf = new Cpf("04714760130"),
                Email = "fm.cab@live.com"
            };
        }
        
        public List<Morador> FindAll()
        {
            List<Morador> moradores = new List<Morador>();
            for (int i = 0; i < 8; i++)
            {
                Morador morador = MockMorador(i);
                moradores.Add(morador);
            }
            return moradores;
        }
        
        public Morador Update(Morador morador)
        {
            return morador;
        }

        private Morador MockMorador(object i)
        {
            return new Morador
            {
                Id = IncrementAndGet(),
                PrimeiroNome = "Fxcvxcv",
                Sobrenome = "vxcvx",
                DataNasciment = new DateTime(05/04/1995),
                Telefone = "999999499",
                Cpf = new Cpf("04714760130"),
                Email = "fm.cab@liccve.com"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}