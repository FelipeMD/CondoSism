using System.Collections.Generic;
using WebApplication1.Domain.Generics;

namespace WebApplication1.Domain.Moradores.Interfaces
{
    public interface IMoradorRepository : IRepository<Morador>
    {
        Morador Disable(long id);
        List<Morador> FindByName(string firstName, string secondName);
    }
}