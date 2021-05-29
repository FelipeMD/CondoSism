using System.Collections.Generic;
using System.Threading;
using WebApplication1.Domain.Apartamentos.Interfaces;
using WebApplication1.Domain.Moradores;
using WebApplication1.Infrastructure.Generic;

namespace WebApplication1.Domain.Apartamentos
{
    public class ApartamentoService : IApartamentoService
    {
        private readonly IRepository<Apartamento> _repository;
        public ApartamentoService(IRepository<Apartamento> repository)
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