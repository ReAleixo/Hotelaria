using Hotelaria.Domain.Entities;

namespace Hotelaria.Tests.Domain
{
    public class ClienteTests
    {
        [Fact]
        public void InstanceCreatesSuccessfully()
        {
            string nome = "João Silva";
            string cpf = "12345678901";
            DateTime dataNascimento = new DateTime(1990, 1, 1);
            Cliente cliente = new Cliente(nome, cpf, dataNascimento);
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData("João", "12345678901", "1990-01-01")]
        [InlineData("João Silva", "123456789", "1990-01-01")]
        [InlineData("João Silva", "12345678901", "2025-12-31")]
        public void InstanceThrowsArgumentException(string nome, string cpf, string dataNascimento)
        {
            DateTime data = DateTime.Parse(dataNascimento);
            Assert.Throws<ArgumentException>(() => new Cliente(nome, cpf, data));
        }


        [Theory]
        [InlineData("", "12345678901", "1990-01-01")]
        [InlineData("João Silva", "", "1990-01-01")]
        public void InstanceThrowsArgumentNullException(string nome, string cpf, string dataNascimento)
        {
            DateTime data = DateTime.Parse(dataNascimento);
            Assert.Throws<ArgumentNullException>(() => new Cliente(nome, cpf, data));
        }
    }
}
