namespace Hotelaria
{
    public class Reserva
    {

        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int QuantidadePessoas { get; set; }

        public Reserva(Hotel hotel, Quarto quarto, DateTime dataEntrada, DateTime dataSaida, int quantidadePessoas)
        {
            Hotel = hotel;
            if (Hotel.QuartosDisponiveis.Contains(quarto))
            {
                Quarto = quarto;
                DataEntrada = dataEntrada;
                DataSaida = dataSaida;
                QuantidadePessoas = quantidadePessoas;
                Id = new Random().Next(20000, 100000);
                return;
            }
            throw new Exception("Quarto não disponível. Por favor confira a lista de quartos disponíveis");
        }

        public string ConferirQuartosDisponiveis(Hotel hotel)
        {

            if (hotel.QuartosDisponiveis == null || hotel.QuartosDisponiveis.Count.Equals(default))
            {
                return "O hotel escolhido não possui quartos disponíveis no momento.";
            }

            if (hotel.QuartosDisponiveis.Count.Equals(1))
            {
                return $"O hotel {hotel.Nome} possui disponível apenas o quarto {hotel.QuartosDisponiveis}.";
            }

            return $"O hotel {hotel.Nome} possui os seguintes quartos dísponíveis: {hotel.QuartosDisponiveis}";
        }
    }
}
