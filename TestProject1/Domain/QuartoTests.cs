using Hotelaria.Domain.Entities;

namespace Hotelaria.Tests.Domain
{
    public class QuartoTests
    {
        [Fact]
        public void InstanceCreatesSuccessfully()
        {
            int numero = 1;
            int metrosQuadrados = 20;
            int numeroComodos = 2;
            int numeroCamas = 2;
            decimal preco = 100;
            Quarto quarto = new Quarto(numero, metrosQuadrados, numeroComodos, numeroCamas, preco);
            Assert.NotNull(quarto);
        }

        [Theory]
        [InlineData(0, 20, 2, 2, 100)]
        [InlineData(1, 0, 2, 2, 100)]
        [InlineData(1, 20, 0, 2, 100)]
        [InlineData(1, 20, 2, 0, 100)]
        [InlineData(1, 20, 2, 2, 0)]
        [InlineData(-1, 20, 2, 2, 100)]
        [InlineData(1, -20, 2, 2, 100)]
        [InlineData(1, 20, -2, 2, 100)]
        [InlineData(1, 20, 2, -2, 100)]
        [InlineData(1, 20, 2, 2, -100)]
        public void InstanceThrowsArgumentException(int numero, int metrosQuadrados, int numeroComodos, int numeroCamas, decimal preco)
        {
            Assert.Throws<ArgumentException>(() => new Quarto(numero, metrosQuadrados, numeroComodos, numeroCamas, preco));
        }
    }  
}
