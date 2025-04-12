using Hotelaria.Domain.Entities;

namespace Hotelaria.Domain.ValueObject
{
    public class Andar
    {
        public int Numero { get; set; }
        public List<Quarto> Quartos { get; set; }

        public Andar(int numero, List<Quarto> quartos)
        {
            Numero = numero;
            Quartos = quartos;
        }
    }
}
