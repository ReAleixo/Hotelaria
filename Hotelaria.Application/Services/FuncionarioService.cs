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

        public async Task CriarFuncionario(Funcionario funcionario)
        {
            if (funcionario == null)
            {
                throw new ArgumentNullException("Funcionário não pode ser nulo.");
            }

            if (await _funcionarioRepository.GetById(funcionario.Id) != null)
            {
                throw new Exception("Funcionário já existe.");
            }

            funcionario.ValidarDadosCadastro();
            await _funcionarioRepository.Add(funcionario);
        }

        public async Task RemoverFuncionario(Funcionario funcionario)
        {
            ProcurarFuncionario(funcionario);
            await _funcionarioRepository.Delete(funcionario);
        }

        public async Task<IEnumerable<Funcionario>> GetAll()
        {
            return await _funcionarioRepository.GetAll();
        }

        public async Task<Funcionario> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("Id não pode ser vazio.");
            }
            return await _funcionarioRepository.GetById(id) ?? throw new Exception("Funcionário não encontrado.");
        }

        public async Task AtualizarFuncionario(Funcionario funcionario)
        {
            ProcurarFuncionario(funcionario);
            funcionario.ValidarDadosCadastro();
            await _funcionarioRepository.Update(funcionario);
        }

        private async void ProcurarFuncionario(Funcionario funcionario)
        {
            if (funcionario == null)
            {
                throw new ArgumentNullException("Funcionário não pode ser nulo.");
            }
            if (funcionario.Id == Guid.Empty)
            {
                throw new ArgumentNullException("Id não pode ser vazio.");
            }
            if (await _funcionarioRepository.GetById(funcionario.Id) == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }
        }
    }
}