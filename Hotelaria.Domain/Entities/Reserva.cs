namespace Hotelaria.Domain.Entities
{
    public class Reserva
    {
        public Guid Id { get; private set; }
        public Cliente Cliente { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }

        public Reserva(
            Cliente cliente,
            Quarto quarto,
            DateTime dataEntrada,
            DateTime dataSaida)
        {
            try
            {
                Id = Guid.NewGuid();
                Cliente = cliente;
                Cliente.ValidarDadosCadastro();
                Quarto = quarto;
                Quarto.ValidarDadosCadastro();
                DataEntrada = dataEntrada;
                DataSaida = dataSaida;
                ValidarDadosCadastro();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível realizar a sua reserva devido ao descrito abaixo:\n\n{ex.Message}");
            }
        }

        public void ValidarDadosCadastro()
        {
            if (Cliente == null)
            {
                throw new ArgumentException("Cliente não pode ser nulo.");
            }
            if (Quarto == null)
            {
                throw new ArgumentException("Quarto não pode ser nulo.");
            }
            if (DataEntrada == default)
            {
                throw new ArgumentException("Data de entrada não pode ser vazia.");
            }
            if (DataSaida == default)
            {
                throw new ArgumentException("Data de saída não pode ser vazia.");
            }
            if (DataEntrada > DataSaida)
            {
                throw new ArgumentException("Data de entrada não pode ser maior que a data de saída.");
            }
        }
    }
}
