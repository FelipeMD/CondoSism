using System.Collections.Generic;

namespace Application.Services.Apartamentos.Interfaces
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