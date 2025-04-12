using Hotelaria.Domain.Entities;

namespace Hotelaria.Application.Interfaces
{
    public interface IQuartoService
    {
        Task<IEnumerable<Quarto>> GetAll();
        Task<Quarto> GetById(Guid id);
        Task AdicionarQuarto(Quarto quarto);
        Task AtualizarQuarto(Quarto quarto);
        Task RemoverQuarto(Quarto quarto);
    }
}
