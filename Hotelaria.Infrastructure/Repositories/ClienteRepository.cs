﻿using Dapper;
using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;
using System.Data;

namespace Hotelaria.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _dbConnection;
        public async Task Add(Cliente cliente)
        {
            string sql = @"INSERT INTO Cliente (Nome, Documento, DataNascimento) 
                                        VALUES (@Nome, @Documento, @DataNascimento)";
            await _dbConnection.ExecuteAsync(sql, new { cliente.Nome, cliente.Documento, cliente.DataNascimento });
        }

        public async Task Delete(Cliente cliente)
        {
            string sql = "DELETE FROM Cliente WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { cliente.Id });
        }

        public async Task<Cliente> GetById(Guid id)
        {
            string sql = "SELECT * FROM Cliente WHERE Id = @Id";
            Cliente cliente = await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id });
            return cliente ?? throw new Exception("Cliente não encontrado.");
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            string sql = "SELECT * FROM Cliente";
            IEnumerable<Cliente> clientes = await _dbConnection.QueryAsync<Cliente>(sql);
            return clientes.ToList();
        }

        public async Task Update(Cliente cliente)
        {
            string sql = @"UPDATE Cliente 
                              SET Nome = @Nome,
                                  Documento = @Documento,
                                  DataNascimento = @DataNascimento
                            WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { cliente.Nome, cliente.Documento, cliente.DataNascimento, cliente.Id });
        }
    }
}
