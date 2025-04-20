using Hotelaria.Application.Interfaces;
using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;

namespace Hotelaria.Application.Services
{
    class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AdicionarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException("O cliente não pode ser nulo");
            }

            if (await _clienteRepository.GetById(cliente.Id) != null)
            {
                throw new Exception("Cliente já existe");
            }

            cliente.ValidarDadosCadastro();
            await _clienteRepository.Add(cliente);
        }

        public async Task RemoverCliente(Cliente cliente)
        {
            ProcurarCliente(cliente);
            await _clienteRepository.Delete(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("O id não pode ser vazio");
            }
            return await _clienteRepository.GetById(id);
        }

        public async Task AtualizarCliente(Cliente cliente)
        {
            ProcurarCliente(cliente);
            cliente.ValidarDadosCadastro();
            await _clienteRepository.Update(cliente);
        }

        private async void ProcurarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException("O cliente não pode ser nulo");
            }
            if (cliente.Id == Guid.Empty)
            {
                throw new ArgumentNullException("Id não pode ser vazio.");
            }
            if (await _clienteRepository.GetById(cliente.Id) == null)
            {
                throw new Exception("Cliente não encontrado");
            }
        }
    }
}
