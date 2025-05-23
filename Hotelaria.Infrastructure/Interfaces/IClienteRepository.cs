﻿using Hotelaria.Domain.Entities;

namespace Hotelaria.Infrastructure.Interfaces
{
    public interface IClienteRepository
    {
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(Cliente cliente);
        Task<Cliente> GetById(Guid id);
        Task<IEnumerable<Cliente>> GetAll();
    }
}
