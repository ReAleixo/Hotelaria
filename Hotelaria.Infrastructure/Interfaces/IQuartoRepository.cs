using Hotelaria.Domain.Entities;

namespace Hotelaria.Infrastructure.Interfaces
{
    public interface IQuartoRepository
    {
        Task Add(Quarto quarto);
        Task Update(Quarto quarto);
        Task Delete(Quarto quarto);
        Task<Quarto> GetById(Guid id);
        Task<IEnumerable<Quarto>> GetAll();
    }
}
