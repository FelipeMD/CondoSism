using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Converter.Contracts;
using WebApplication1.Data.ValueObjetcs;
using WebApplication1.Domain.Moradores;

namespace WebApplication1.Data.Converter.Implementations
{
    public class MoradorConverter : IParser<MoradorVo, Morador>, IParser<Morador, MoradorVo>
    {
        public Morador Parse(MoradorVo origin)
        {
            if (origin == null) return null;
            return new Morador
            {
                Id = origin.Id,
                PrimeiroNome = origin.PrimeiroNome,
                Sobrenome = origin.Sobrenome,
                DataNasciment = origin.DataNasciment,
                Telefone = origin.Telefone,
                Cpf = origin.Cpf,
                Email = origin.Email
            };
        }
        
        public MoradorVo Parse(Morador origin)
        {
            if (origin == null) return null;
            return new MoradorVo()
            {
                Id = origin.Id,
                PrimeiroNome = origin.PrimeiroNome,
                Sobrenome = origin.Sobrenome,
                DataNasciment = origin.DataNasciment,
                Telefone = origin.Telefone,
                Cpf = origin.Cpf,
                Email = origin.Email
            };
        }
        
        public List<Morador> Parse(List<MoradorVo> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<MoradorVo> Parse(List<Morador> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}