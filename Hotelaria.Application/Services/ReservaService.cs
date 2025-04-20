using Hotelaria.Application.Interfaces;
using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;

namespace Hotelaria.Application.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task AdicionarReserva(Reserva reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException("Reserva não pode ser nula.");
            }

            if (await _reservaRepository.GetById(reserva.Id) != null)
            {
                throw new ArgumentException("Reserva já existe.");
            }

            await _reservaRepository.Add(reserva);
        }

        public async Task AtualizarReserva(Reserva reserva)
        {
            ProcurarReserva(reserva);
            await _reservaRepository.Update(reserva);
        }

        public async Task CancelarReserva(Reserva reserva)
        {
            ProcurarReserva(reserva);
            await _reservaRepository.Delete(reserva);
        }

        public async Task<Reserva> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("Id não pode ser vazio.");
            }
            return await _reservaRepository.GetById(id);
        }

        public async void ProcurarReserva(Reserva reserva)
        {
            if (reserva == null)
            {
                throw new ArgumentNullException("Reserva não pode ser nula.");
            }
            if (reserva.Id == Guid.Empty)
            {
                throw new ArgumentNullException("Id não pode ser vazio.");
            }
            if (await _reservaRepository.GetById(reserva.Id) == null)
            {
                throw new ArgumentException("Reserva não encontrada.");
            }
        }
    }
}
