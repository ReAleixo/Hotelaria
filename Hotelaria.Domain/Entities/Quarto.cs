using Hotelaria.Domain.ValueObject;

namespace Hotelaria.Domain.Entities
{
    public class Quarto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int MetrosQuadrados { get; set; }
        public Andar Andar { get; set; }
        public int NumeroComodos { get; set; }
        public int NumeroCamas { get; set; }
        public bool EstaDisponivel { get; set; }
        public bool EstaLimpo { get; set; }
        public decimal Preco { get; set; }
    }
}
