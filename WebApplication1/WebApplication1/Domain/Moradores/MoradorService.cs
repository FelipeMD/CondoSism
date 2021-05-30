using System.Collections.Generic;
using WebApplication1.Data.Converter.Implementations;
using WebApplication1.Data.ValueObjetcs;
using WebApplication1.Domain.Generics;
using WebApplication1.Domain.Moradores.Interfaces;
using WebApplication1.Infrastructure.Repositories;

namespace WebApplication1.Domain.Moradores
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
        
        public MoradorVo FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
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