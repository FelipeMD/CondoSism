using System.Collections.Generic;
using API.Hypermedia;
using API.Hypermedia.Abstract;

namespace API.Data.ValueObjetcs
{
    public class ApartamentoVo : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public int Numero { get; set; }
        public string Bloco { get; set; }
        
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}