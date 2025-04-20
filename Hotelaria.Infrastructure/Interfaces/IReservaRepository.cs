using Hotelaria.Domain.Entities;

namespace Hotelaria.Infrastructure.Interfaces
{
    public interface IReservaRepository
    {
        Task Add(Reserva reserva);
        Task Update(Reserva reserva);
        Task Delete(Reserva reserva);
        Task<Reserva> GetById(Guid id);
    }
}
