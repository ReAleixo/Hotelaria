using Hotelaria.Domain.Entities;

namespace Hotelaria.Application.Interfaces
{
    public interface IReservaService
    {
        Task AdicionarReserva(Reserva reserva);
        Task AtualizarReserva(Reserva reserva);
        Task CancelarReserva(Reserva reserva);
        Task<Reserva> GetById(Guid id);
    }
}
