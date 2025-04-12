using Hotelaria.Domain.Entities;

namespace Hotelaria.Application.Interfaces
{
    public interface IClienteService
    {
        Task AdicionarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task RemoverCliente(Cliente cliente);
        Task<Cliente> GetById(Guid id);
        Task<IEnumerable<Cliente>> GetAll();
    }
}
