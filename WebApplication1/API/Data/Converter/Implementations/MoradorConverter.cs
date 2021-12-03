using System.Collections.Generic;
using System.Linq;
using API.Data.Converter.Contracts;
using API.Data.ValueObjetcs;
using API.Domain.Entities.Moradores;

namespace API.Data.Converter.Implementations
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
                Email = origin.Email,
                Enabled = origin.Enabled
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
                Email = origin.Email,
                Enabled = origin.Enabled
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