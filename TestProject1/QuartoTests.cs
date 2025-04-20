using Hotelaria.Domain.Entities;

namespace Hotelaria.Tests
{
    public class QuartoTests
    {
        [Fact]
        public void Quarto_ValidarDadosCadastro_ThrowsArgumentException()
        {
            // Arrange
            var quarto = new Quarto(0, 0, 0, 0, 0);
            // Act & Assert
            Assert.Throws<ArgumentException>(quarto.ValidarDadosCadastro);
        }

        [Fact]
        public void Quarto_ValidarDadosCadastro_Success()
        {
            // Arrange
            var quarto = new Quarto(1, 20, 2, 2, 100);
            // Act & Assert
            quarto.ValidarDadosCadastro();
        }
    }  
}
