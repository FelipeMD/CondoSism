using System.Collections.Generic;
using API.Domain.Generics;

namespace API.Domain.Entities.Moradores.Interfaces
{
    public interface IMoradorRepository : IRepository<Morador>
    {
        Morador Disable(long id);
        List<Morador> FindByName(string firstName, string secondName);
    }
}