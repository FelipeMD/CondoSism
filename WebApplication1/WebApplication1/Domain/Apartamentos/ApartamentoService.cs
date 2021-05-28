using System.Collections.Generic;
using System.Threading;
using WebApplication1.Domain.Apartamentos.Interfaces;
using WebApplication1.Domain.Moradores;
using WebApplication1.Infrastructure.Repository;

namespace WebApplication1.Domain.Apartamentos
{
    public class ApartamentoService : IApartamentoService
    {
        private readonly IApartamentoRepository _repository;

        public ApartamentoService(IApartamentoRepository repository)
        {
            _repository = repository;
        }

        public Apartamento FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Apartamento> FindAll()
        {
            return _repository.FindAll();
        }
        
        public Apartamento Create(Apartamento apartamento)
        {
            return _repository.Create(apartamento);
        }
        
        public Apartamento Update(Apartamento apartamento)
        {
            return _repository.Update(apartamento);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}