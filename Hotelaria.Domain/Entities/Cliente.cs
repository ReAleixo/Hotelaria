namespace Hotelaria.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public Guid Id { get; set; }
        public Reserva Reserva { get; set; }

        public Cliente()
        {

        }
    }
}
