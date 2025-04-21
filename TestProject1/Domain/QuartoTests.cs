using Hotelaria.Domain.Entities;

namespace Hotelaria.Tests.Domain
{
    public class QuartoTests
    {
        [Fact]
        public void InstanceCreatesSuccessfully()
        {
            Quarto quarto = new Quarto(1, 20, 2, 2, 100);
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
