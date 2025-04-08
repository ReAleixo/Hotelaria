using Hotelaria.Domain.Entities;

namespace Hotelaria.Application.Interfaces
{
    public interface IClienteService
    {
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(Cliente cliente);
        Task<Cliente> GetById(int id);
        Task<IEnumerable<Cliente>> GetAll();
    }
}
