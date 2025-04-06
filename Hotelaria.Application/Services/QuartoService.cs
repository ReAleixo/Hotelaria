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

        public async Task Add(Quarto quarto)
        {
            await _quartoRepository.Add(quarto);
        }

        public async Task Delete(Quarto quarto)
        {
            await _quartoRepository.Delete(quarto);
        }

        public async Task<IEnumerable<Quarto>> GetAll()
        {
            return await _quartoRepository.GetAll();
        }

        public async Task<Quarto> GetById(int id)
        {
            return await _quartoRepository.GetById(id);
        }

        public async Task Update(Quarto quarto)
        {
            await _quartoRepository.Update(quarto);
        }
    }
}
