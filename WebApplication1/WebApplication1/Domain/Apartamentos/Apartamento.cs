using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Domain.Moradores;

namespace WebApplication1.Domain.Apartamentos
{
    [Table("apartamento")]
    public class Apartamento
    {
        [Column("id")]
        public long Id { get; set; }
        
        [Column("numero")]
        public int Numero { get; set; }
        
        [Column("bloco")]
        public string Bloco { get; set; }
        
        // public long MoradorId { get; set; }
        // public List<Morador> Moradores { get; set; }
    }
}