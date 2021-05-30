using System.Collections.Generic;
using WebApplication1.Data.ValueObjetcs;

namespace WebApplication1.Domain.Apartamentos.Interfaces
{
    public interface IApartamentoService
    {
        ApartamentoVo Create(ApartamentoVo apartamento);
        ApartamentoVo FindById(long id);
        List<ApartamentoVo> FindAll();
        ApartamentoVo Update(ApartamentoVo apartamento);
        void Delete(long id);
    }
}