using System.Collections.Generic;
using System.Threading;
using WebApplication1.Domain.Apartamentos.Interfaces;
using WebApplication1.Domain.Moradores;

namespace WebApplication1.Domain.Apartamentos
{
    public class ApartamentoService : IApartamentoService
    {
        private volatile int count;
        
        public Apartamento Create(Apartamento apartamento)
        {
            return apartamento;
        }

        public Apartamento FindById(long id)
        {
            return new Apartamento()
            {
                Id = IncrementAndGet(),
                Numero = 1,
                Bloco = "B-1",
                // MoradorId = 1,
                // Moradores = new List<Morador>()
            };
        }

        public List<Apartamento> FindAll()
        {
            List<Apartamento> apartamentos = new List<Apartamento>();
            for (int i = 0; i < 8; i++)
            {
                Apartamento apartamento = MockApartamento(i);
                apartamentos.Add(apartamento);
            }
            return apartamentos;
        }
        
        public Apartamento Update(Apartamento apartamento)
        {
            return apartamento;
        }

        public void Delete(long id)
        {
            //TODO: implementar delete
        }
        
        private Apartamento MockApartamento(int i)
        {
            return new Apartamento()
            {
                Id = IncrementAndGet(),
                Numero = 1,
                Bloco = "B-1",
                // MoradorId = 1,
                // Moradores = new List<Morador>()
            };
        }
        
        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}