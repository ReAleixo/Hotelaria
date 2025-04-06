using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;

namespace Hotelaria.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public Task Add(Cliente cliente)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }
        public Task<Cliente> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Cliente>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
