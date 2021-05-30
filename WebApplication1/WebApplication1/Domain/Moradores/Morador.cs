using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;
using WebApplication1.Domain.Base;

namespace WebApplication1.Domain.Moradores
{
    [Table("morador")]
    public class Morador : BaseEntity
    {
        [Column("nome")]
        public string PrimeiroNome { get; set; }
        
        [Column("sobrenome")]
        public string Sobrenome { get; set; }
        
        [Column("nascimento")]
        public DateTime DataNasciment { get; set; }
        
        [Column("telefone")]
        public string Telefone { get; set; }
        
        [Column("cpf")]
        public string Cpf { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("enabled")]
        public bool Enabled { get; set; }
    }
}