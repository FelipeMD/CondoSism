using System.Collections.Generic;
using WebApplication1.Domain.Moradores;

namespace WebApplication1.Domain.Apartamentos
{
    public class Apartamento
    {
        public long Id { get; set; }
        public int Numero { get; set; }
        public string Bloco { get; set; }
        
        // public long MoradorId { get; set; }
        // public List<Morador> Moradores { get; set; }
    }
}