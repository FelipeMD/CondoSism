using System.Collections.Generic;

namespace Application.Services.Moradores.Interfaces
{
    public interface IMoradorService
    {
        MoradorVo Create(MoradorVo morador);
        MoradorVo FindById(long id);
        List<MoradorVo> FindByName(string firstName, string lastName);
        List<MoradorVo> FindAll();
        PagedSearchVo<MoradorVo> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        MoradorVo Update(MoradorVo morador);
        MoradorVo Disable(long id);
        void Delete(long id);
    }
}