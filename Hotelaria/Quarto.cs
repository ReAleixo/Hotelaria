namespace Hotelaria
{
    public class Quarto
    {
        public int Numero { get; set; }
        public int MetrosQuadrados { get; set; }
        public Andar Andar { get; set; }
        public int NumeroComodos { get; set; }
        public int NumeroCamas { get; set; }
        public bool Disponivel { get; set; }
        public bool Limpo { get; set; }
        public decimal Preco { get; set; }

        public Quarto()
        {

        }
    }
}
