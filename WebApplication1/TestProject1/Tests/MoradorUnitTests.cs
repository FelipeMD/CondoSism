using Moq;
using WebApplication1.Domain.Moradores;
using WebApplication1.Domain.Moradores.Interfaces;
using Xunit;

namespace TestProject1.Tests
{
    public class MoradorUnitTests
    {
        private readonly IMoradorService _moradorService;

        public MoradorUnitTests()
        {
            _moradorService = new MoradorService(new Mock<IMoradorRepository>().Object);
        }
        
        [Fact]
        public void InserindoDadosNulos_MoradorNaoCadastrado()
        {
            var act = _moradorService.Create(new Morador());
            
            Assert.Null(act);
        }
    }
}