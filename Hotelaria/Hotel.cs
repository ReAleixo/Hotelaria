namespace Hotelaria
{
    public class Hotel
    {
        public string Nome { get; set; }
        public List<Quarto> Quartos { get; set; }
        public List<Quarto> QuartosDisponiveis { get; set; }
        public int NumeroAndares { get; set; }
        public Endereco Endereco { get; set; }

        public Hotel()
        {

        }
    }
}
