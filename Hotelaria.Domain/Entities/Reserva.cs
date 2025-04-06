namespace Hotelaria.Domain.Entities
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
            if (Hotel.QuartosDisponiveis != null 
                && Hotel.QuartosDisponiveis.Contains(quarto))
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
    }
}
