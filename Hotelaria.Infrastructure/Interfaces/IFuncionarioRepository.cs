using Hotelaria.Domain.Entities;

namespace Hotelaria.Infrastructure.Interface
{
    interface IFuncionarioRepository
    {
        Task Add(Funcionario funcionario);
        Task Update(Funcionario funcionario);
        Task Delete(Funcionario funcionario);
        Task<Funcionario> GetById(int id);
        Task<IEnumerable<Funcionario>> GetAll();
    }
}
