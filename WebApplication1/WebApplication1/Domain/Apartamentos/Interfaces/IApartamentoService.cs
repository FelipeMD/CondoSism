using System.Collections.Generic;

namespace WebApplication1.Domain.Apartamentos.Interfaces
{
    public interface IApartamentoService
    {
        Apartamento Create(Apartamento apartamento);
        Apartamento FindById(long id);
        List<Apartamento> FindAll();
        Apartamento Update(Apartamento apartamento);
        void Delete(long id);
    }
}