using System.Collections.Generic;
using WebApplication1.Hypermedia;
using WebApplication1.Hypermedia.Abstract;

namespace WebApplication1.Data.ValueObjetcs
{
    public class ApartamentoVo : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public int Numero { get; set; }
        public string Bloco { get; set; }
        
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}