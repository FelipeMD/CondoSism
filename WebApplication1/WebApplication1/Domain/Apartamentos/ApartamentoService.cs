using System.Collections.Generic;
using System.Threading;
using WebApplication1.Data.Converter.Implementations;
using WebApplication1.Data.ValueObjetcs;
using WebApplication1.Domain.Apartamentos.Interfaces;
using WebApplication1.Domain.Moradores;
using WebApplication1.Infrastructure.Generic;

namespace WebApplication1.Domain.Apartamentos
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