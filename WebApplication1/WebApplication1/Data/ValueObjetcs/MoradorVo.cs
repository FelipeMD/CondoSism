using System;

namespace WebApplication1.Data.ValueObjetcs
{
    
    public class MoradorVo
    {
        public long Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNasciment { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}