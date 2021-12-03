using System;
using System.Collections.Generic;
using API.Hypermedia;
using API.Hypermedia.Abstract;

namespace API.Data.ValueObjetcs
{
    
    public class MoradorVo : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNasciment { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
        
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}