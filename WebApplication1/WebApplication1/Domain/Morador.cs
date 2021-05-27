using Microsoft.VisualBasic;
using WebApplication1.Domain.ValueObjetcs;

namespace WebApplication1.Domain
{
    public class Morador
    {
        public long Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateFormat DataNasciment { get; set; }
        public long Telefone { get; set; }
        public Cpf Cpf { get; set; }
        public string Email { get; set; }
    }
}