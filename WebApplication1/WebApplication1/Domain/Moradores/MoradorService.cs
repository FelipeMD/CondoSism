using System.Collections.Generic;
using WebApplication1.Domain.Moradores.Interfaces;
using WebApplication1.Infrastructure.Generic;

namespace WebApplication1.Domain.Moradores
{
    public class MoradorService : IMoradorService
    {
        private readonly IRepository<Morador> _repository;
        public MoradorService(IRepository<Morador> repository)
        {
            _repository = repository;
        }
        
        public List<Morador> FindAll()
        {
            return _repository.FindAll();
        }
        
        public Morador FindById(long id)
        {
            return _repository.FindById(id);
        }
        
        public Morador Create(Morador morador)
        {
           return _repository.Create(morador);
        }

        public Morador Update(Morador morador)
        {
            return _repository.Update(morador);
        }
        
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        
        public void Exists(long id)
        {
            _repository.Exists(id);
        }
    }
}