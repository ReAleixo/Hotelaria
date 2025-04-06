﻿using Hotelaria.Domain.Entities;

namespace Hotelaria.Infrastructure.Interface
{
    interface IQuartoRepository
    {
        Task Add(Quarto quarto);
        Task Update(Quarto quarto);
        Task Delete(Quarto quarto);
        Task<Quarto> GetById(int id);
        Task<IEnumerable<Quarto>> GetAll();
    }
}
