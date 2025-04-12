namespace Hotelaria.Domain.Entities
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public Hotel Hotel { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int QuantidadePessoas { get; set; }

        public Reserva(
            Hotel hotel,
            Quarto quarto,
            DateTime dataEntrada,
            DateTime dataSaida,
            int quantidadePessoas)
        {
            Id = Guid.NewGuid();
            Hotel = hotel;
            Quarto = quarto;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
            QuantidadePessoas = quantidadePessoas;
            ValidarDadosCadastro();
            ValidarReserva();
        }

        public void ValidarDadosCadastro()
        {
            if (Hotel == null)
            {
                throw new ArgumentException("Hotel não pode ser nulo.");
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
            if (QuantidadePessoas <= 0)
            {
                throw new ArgumentException("Quantidade de pessoas deve ser maior que zero.");
            }
        }

        public void ValidarReserva()
        {
            if (Hotel.QuartosDisponiveis == null || Hotel.QuartosDisponiveis.Count.Equals(default))
            {
                throw new Exception("O hotel escolhido não possui quartos disponíveis no momento.");
            }
            if (!Hotel.Quartos.Contains(Quarto))
            {
                throw new Exception($"O hotel {Hotel.Nome} não tem o quarto selecionado.");
            }
            if (!Hotel.QuartosDisponiveis.Contains(Quarto))
            {
                throw new Exception($"O quarto {Quarto.Numero} não está disponível no momento.");
            }
            if (!Quarto.EstaDisponivel)
            {
                throw new Exception($"O quarto {Quarto.Numero} não está disponível no momento.");
            }
            if (!Quarto.EstaLimpo)
            {
                throw new Exception($"O quarto {Quarto.Numero} não está limpo.");
            }
        }
    }
}
