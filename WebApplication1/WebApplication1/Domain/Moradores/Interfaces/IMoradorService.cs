using System.Collections.Generic;

namespace WebApplication1.Domain.Moradores.Interfaces
{
    public interface IMoradorService
    {
        Morador Create(Morador morador);
        Morador FindById(long id);
        List<Morador> FindAll();
        Morador Update(Morador morador);
        void Delete(long id);
        void Exists(long id);
    }
}