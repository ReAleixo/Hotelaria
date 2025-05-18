using Hotelaria.Domain.Entities;
using Hotelaria.Domain.ValueObject;

namespace Hotelaria.Tests.Domain
{
    public class HotelTests
    {
        public static IEnumerable<object[]> InvalidInstances =
            new List<object[]>
            {
                new object[] { "Hotel Teste", null, 16, new List<Quarto>() { new Quarto(1, 70, 2, 1, 400) } },
                new object[] { "Hotel Teste", new Endereco("Rua Teste", 123, "Centro", "São Paulo", "SP", "01234-567"), -1, new List<Quarto>() { new Quarto(1, 70, 2, 1, 400) } },
                new object[] { "Hotel Teste", new Endereco("Rua Teste", 123, "Centro", "São Paulo", "SP", "01234-567"), 16, new List<Quarto>() },
                new object[] { "Hotel Teste", new Endereco("Rua Teste", 123, "Centro", "São Paulo", "SP", "01234-567"), 16, null }
            };

        public static IEnumerable<object[]> InvalidInstancesWithEmptyName =
            new List<object[]>
            {
                new object[] { "", new Endereco("Rua Teste", 123, "Centro", "São Paulo", "SP", "01234-567"), 16, new List<Quarto>() { new Quarto(1, 70, 2, 1, 400) } },
                new object[] { null, new Endereco("Rua Teste", 123, "Centro", "São Paulo", "SP", "01234-567"), 16, new List<Quarto>() { new Quarto(1, 70, 2, 1, 400) } }
            };

        [Fact]
        public void InstanceCreatesSuccessfully()
        {
            string nome = "Hotel Teste";
            Endereco endereco = new Endereco("Rua Teste", 123, "Centro", "São Paulo", "SP", "01234-567");
            int numeroAndares = 16;
            List<Quarto> quartos = new List<Quarto>
            {
                new Quarto(1, 100, 3, 2, 650),
                new Quarto(2, 70, 2, 1, 400)
            };
            Hotel hotel = new Hotel(nome, endereco, numeroAndares, quartos);
            Assert.NotNull(hotel);
        }

        [Theory]
        [MemberData(nameof(InvalidInstances))]
        public void InstanceThrowsArgumentException(string nome, Endereco endereco, int numeroAndares, List<Quarto> quartos)
        {
            Assert.Throws<ArgumentException>(() => new Hotel(nome, endereco, numeroAndares, quartos));
        }

        [Theory]
        [MemberData(nameof(InvalidInstancesWithEmptyName))]
        public void InstanceThrowsArgumentNullException(string nome, Endereco endereco, int numeroAndares, List<Quarto> quartos)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(nome, endereco, numeroAndares, quartos));
        }
    }
}
