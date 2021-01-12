using Localiza.Componentes.ConjuntosNumericos.Services;
using Localiza.Componentes.ConjuntosNumericos.Services.Interfaces;
using Xunit;

namespace Localiza.Componentes.ConjutosNumericos.Tests
{
    public class CalculaDivisoresPrimosTest
    {
        private readonly IDivisoresService _divisoresService;

        public CalculaDivisoresPrimosTest()
        {
            _divisoresService = new DivisoresService();
        }

        [Fact]
        public void Calcula_os_primos_de_um_determinado_numero()
        {
            // Arrange
            var numeroEntrada = 45;

            // Act
            var retorno = _divisoresService.ObterDivisoresPrimos(numeroEntrada);

            // Assert
            Assert.Equal(45, numeroEntrada);

            Assert.Collection(retorno.DivisoresPrimos,
                item => Assert.Equal(1, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(5, item));
        }
    }
}
