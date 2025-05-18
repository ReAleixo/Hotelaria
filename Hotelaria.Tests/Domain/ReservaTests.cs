using Hotelaria.Domain.Entities;

namespace Hotelaria.Tests.Domain
{
    public class ReservaTests
    {
        public static IEnumerable<object[]> InvalidInstances =
            new List<object[]>
            {
                new object[] { null, new Quarto(1, 20, 2, 2, 100), DateTime.Now, DateTime.Now.AddDays(2) },
                new object[] { new Cliente("João Silva", "12345678901", new DateTime(1990, 1, 1)), null, DateTime.Now, DateTime.Now.AddDays(2) },
                new object[] { new Cliente("João Silva", "12345678901", new DateTime(1990, 1, 1)), new Quarto(1, 20, 2, 2, 100), default, DateTime.Now.AddDays(2) },
                new object[] { new Cliente("João Silva", "12345678901", new DateTime(1990, 1, 1)), new Quarto(1, 20, 2, 2, 100), DateTime.Now, default },
                new object[] { new Cliente("João Silva", "12345678901", new DateTime(1990, 1, 1)), new Quarto(1, 20, 2, 2, 100), DateTime.Now.AddDays(2), DateTime.Now }
            };

        [Fact]
        public void InstanceCreatesSuccessfully()
        {
            Cliente cliente = new Cliente("João Silva", "12345678901", new DateTime(1990, 1, 1));
            Quarto quarto = new Quarto(1, 20, 2, 2, 100);
            Reserva reserva = new Reserva(cliente, quarto, DateTime.Now, DateTime.Now.AddDays(2));
            Assert.NotNull(reserva);
        }

        [Theory]
        [MemberData(nameof(InvalidInstances))]
        public void InstanceThrowsArgumentException(Cliente cliente, Quarto quarto, DateTime dataEntrada, DateTime dataSaida)
        {
            Assert.Throws<Exception>(() => new Reserva(cliente, quarto, dataEntrada, dataSaida));
        }
    }
}