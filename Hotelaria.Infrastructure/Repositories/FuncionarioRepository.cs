using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;

namespace Hotelaria.Infrastructure.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        public Task Add(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
        public Task<Funcionario> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Funcionario>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task Update(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
    }
}