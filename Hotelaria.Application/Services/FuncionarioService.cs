using Hotelaria.Application.Interfaces;
using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;

namespace Hotelaria.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task Add(Funcionario funcionario)
        {
            await _funcionarioRepository.Add(funcionario);
        }

        public async Task Delete(Funcionario funcionario)
        {
            await _funcionarioRepository.Delete(funcionario);
        }

        public async Task<IEnumerable<Funcionario>> GetAll()
        {
            return await _funcionarioRepository.GetAll();
        }

        public async Task<Funcionario> GetById(int id)
        {
            return await _funcionarioRepository.GetById(id);
        }

        public async Task Update(Funcionario funcionario)
        {
            await _funcionarioRepository.Update(funcionario);
        }
    }
}
