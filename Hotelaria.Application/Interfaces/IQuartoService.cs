using Hotelaria.Domain.Entities;

namespace Hotelaria.Application.Interfaces
{
    public interface IQuartoService
    {
        Task<IEnumerable<Quarto>> GetAll();
        Task<Quarto> GetById(int id);
        Task Add(Quarto quarto);
        Task Update(Quarto quarto);
        Task Delete(Quarto quarto);
    }
}
