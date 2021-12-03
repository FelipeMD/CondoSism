using System.Collections.Generic;
using Application.Services.Moradores.Interfaces;

namespace Application.Services.Moradores
{
    public class MoradorService : IMoradorService
    {
        private readonly IMoradorRepository _repository;
        private readonly MoradorConverter _converter;
        public MoradorService(IMoradorRepository repository)
        {
            _repository = repository;
            _converter = new MoradorConverter();
        }

        public List<MoradorVo> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVo<MoradorVo> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) 
                        && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from morador m where 1 = 1";

            if (!string.IsNullOrWhiteSpace(name)) query = query + $"  and m.nome like '%{name}'  ";
            
            query += $" order by m.nome {sort} limit {size} offset {offset}";

            var moradores = _repository.FindWitchPagedSearch(query);

            string countQuery = @"select count(*) from morador m where 1 = 1 ";
            
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $"  and m.name like '%{name}'  ";
            
            
            int totalresults = _repository.GetCount(countQuery);
            
            
            return new PagedSearchVo<MoradorVo>
            {
                CurrentPage = page,
                List = _converter.Parse(moradores),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalresults
            };
        }

        public MoradorVo FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        
        public List<MoradorVo> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }
        
        public MoradorVo Create(MoradorVo morador)
        {
            var moradorEntity = _converter.Parse(morador);
            moradorEntity = _repository.Create(moradorEntity);

            return _converter.Parse(moradorEntity);
        }

        public MoradorVo Update(MoradorVo morador)
        {
            var moradorEntity = _converter.Parse(morador);
            moradorEntity = _repository.Update(moradorEntity);

            return _converter.Parse(moradorEntity);
        }

        public MoradorVo Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}