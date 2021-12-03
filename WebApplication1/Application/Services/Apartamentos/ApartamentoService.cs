using System.Collections.Generic;
using Application.Services.Apartamentos.Interfaces;

namespace Application.Services.Apartamentos
{
    public class ApartamentoService : IApartamentoService
    {
        private readonly IRepository<Apartamento> _repository;
        private readonly ApartamentoConverter _converter;
        public ApartamentoService(IRepository<Apartamento> repository)
        {
            _repository = repository;
            _converter = new ApartamentoConverter();
        }
        
        public List<ApartamentoVo> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public ApartamentoVo FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        
        
        public ApartamentoVo Create(ApartamentoVo apartamento)
        {
            var apartamentoEntity = _converter.Parse(apartamento);
            apartamentoEntity = _repository.Create(apartamentoEntity);

            return _converter.Parse(apartamentoEntity);
        }
        
        public ApartamentoVo Update(ApartamentoVo apartamento)
        {
            var apartamentoEntity = _converter.Parse(apartamento);
            apartamentoEntity = _repository.Update(apartamentoEntity);

            return _converter.Parse(apartamentoEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}