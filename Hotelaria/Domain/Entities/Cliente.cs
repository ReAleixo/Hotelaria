using Hotelaria.Domain.ValueObject;

namespace Hotelaria.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public Reserva Reserva { get; set; }

        public Cliente()
        {

        }
    }
}
