using Hotelaria.ValueObject;

namespace Hotelaria
{
    public class Cliente : Pessoa
    {
        public Reserva Reserva { get; set; }

        public Cliente()
        {

        }
    }
}
