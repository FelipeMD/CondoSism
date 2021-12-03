using System.ComponentModel.DataAnnotations.Schema;
using API.Domain.Entities.Base;

namespace API.Domain.Entities.Apartamentos
{
    [Table("apartamento")]
    public class Apartamento : BaseEntity
    {
        [Column("numero")]
        public int Numero { get; set; }
        
        [Column("bloco")]
        public string Bloco { get; set; }
        
        // public long MoradorId { get; set; }
        // public List<Morador> Moradores { get; set; }
    }
}