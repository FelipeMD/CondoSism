using WebApplication1.Domain.Generics;

namespace WebApplication1.Domain.Moradores.Interfaces
{
    public interface IMoradorRepository : IRepository<Morador>
    {
        Morador Disable(long id);
    }
}