using System.Collections.Generic;

namespace WebApplication1.Data.Converter.Contracts
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}