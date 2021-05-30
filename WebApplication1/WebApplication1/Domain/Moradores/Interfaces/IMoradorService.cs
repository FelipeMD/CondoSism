using System.Collections.Generic;
using WebApplication1.Data.ValueObjetcs;

namespace WebApplication1.Domain.Moradores.Interfaces
{
    public interface IMoradorService
    {
        MoradorVo Create(MoradorVo morador);
        MoradorVo FindById(long id);
        List<MoradorVo> FindAll();
        MoradorVo Update(MoradorVo morador);
        void Delete(long id);
    }
}