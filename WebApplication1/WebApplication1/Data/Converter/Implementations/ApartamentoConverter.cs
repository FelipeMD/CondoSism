﻿using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Converter.Contracts;
using WebApplication1.Data.ValueObjetcs;
using WebApplication1.Domain.Apartamentos;

namespace WebApplication1.Data.Converter.Implementations
{
    public class ApartamentoConverter : IParser<ApartamentoVo, Apartamento>, IParser<Apartamento, ApartamentoVo>

    {
        public Apartamento Parse(ApartamentoVo origin)
        {
            if (origin == null) return null;
            return new Apartamento
            {
                Id = origin.Id,
                Numero = origin.Numero,
                Bloco = origin.Bloco
            };
        }

        public ApartamentoVo Parse(Apartamento origin)
        {
            if (origin == null) return null;
            return new ApartamentoVo
            {
                Id = origin.Id,
                Numero = origin.Numero,
                Bloco = origin.Bloco
            };
        }

        public List<Apartamento> Parse(List<ApartamentoVo> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        
        public List<ApartamentoVo> Parse(List<Apartamento> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}