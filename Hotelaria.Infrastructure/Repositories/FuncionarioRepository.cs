using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interface;

namespace Hotelaria.Infrastructure.Repository
{
    class FuncionarioRepository : IFuncionarioRepository
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