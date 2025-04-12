using Hotelaria.Domain.Entities;

namespace Hotelaria.Application.Interfaces
{
    public interface IFuncionarioService
    {
        Task CriarFuncionario(Funcionario funcionario);
        Task AtualizarFuncionario(Funcionario funcionario);
        Task RemoverFuncionario(Funcionario funcionario);
        Task<Funcionario> GetById(Guid id);
        Task<IEnumerable<Funcionario>> GetAll();
    }
}
