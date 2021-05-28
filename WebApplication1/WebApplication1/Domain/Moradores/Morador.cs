using System;
using Microsoft.VisualBasic;
using WebApplication1.Domain.ValueObjetcs;

namespace WebApplication1.Domain.Moradores
{
    public class Morador
    {
        public long Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNasciment { get; set; }
        public string Telefone { get; set; }
        public Cpf Cpf { get; set; }
        public string Email { get; set; }
    }
}