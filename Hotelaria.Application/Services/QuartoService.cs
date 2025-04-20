using Hotelaria.Application.Interfaces;
using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;

namespace Hotelaria.Application.Services
{
    public class QuartoService : IQuartoService
    {
        private readonly IQuartoRepository _quartoRepository;

        public QuartoService(IQuartoRepository quartoRepository)
        {
            _quartoRepository = quartoRepository;
        }

        public async Task AdicionarQuarto(Quarto quarto)
        {
            if (quarto == null)
            {
                throw new ArgumentNullException("Quarto não pode ser nulo.");
            }

            if (await _quartoRepository.GetById(quarto.Id) != null)
            {
                throw new Exception("Quarto já existe.");
            }

            quarto.ValidarDadosCadastro();
            await _quartoRepository.Add(quarto);
        }

        public async Task RemoverQuarto(Quarto quarto)
        {
            ProcurarQuarto(quarto);
            await _quartoRepository.Delete(quarto);
        }

        public async Task<IEnumerable<Quarto>> GetAll()
        {
            return await _quartoRepository.GetAll();
        }

        public async Task<Quarto> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("Id não pode ser vazio.");
            }
            return await _quartoRepository.GetById(id) ?? throw new Exception("Quarto não encontrado.");
        }

        public async Task AtualizarQuarto(Quarto quarto)
        {
            ProcurarQuarto(quarto);
            quarto.ValidarDadosCadastro();
            await _quartoRepository.Update(quarto);
        }

        private async void ProcurarQuarto(Quarto quarto)
        {
            if (quarto == null)
            {
                throw new ArgumentNullException("Quarto não pode ser nulo.");
            }
            if (quarto.Id == Guid.Empty)
            {
                throw new ArgumentNullException("Id não pode ser vazio.");
            }
            if (await _quartoRepository.GetById(quarto.Id) == null)
            {
                throw new Exception("Quarto não encontrado.");
            }
        }
    }
}
