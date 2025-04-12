using Dapper;
using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;
using System.Data;

namespace Hotelaria.Infrastructure.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IDbConnection _dbConnection;

        public async Task Add(Funcionario funcionario)
        {
            string sql = @"INSERT INTO Funcionario (Nome, Documento, DataNascimento, Cargo, Salario) 
                                            VALUES (@Nome, @Documento, @DataNascimento, @Cargo, @Salario)";
            await _dbConnection.ExecuteAsync(sql, new { funcionario.Nome, funcionario.Documento, funcionario.DataNascimento, funcionario.Cargo, funcionario.Salario });
        }

        public async Task Delete(Funcionario funcionario)
        {
            string sql = "DELETE FROM Funcionario WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { funcionario.Id });
        }

        public async Task<Funcionario> GetById(Guid id)
        {
            string sql = "SELECT * FROM Funcionario WHERE Id = @Id";
            Funcionario funcionario = await _dbConnection.QueryFirstOrDefaultAsync<Funcionario>(sql, new { Id = id });
            return funcionario ?? throw new Exception("Funcionário não encontrado.");
        }

        public async Task<IEnumerable<Funcionario>> GetAll()
        {
            string sql = "SELECT * FROM Funcionario";
            IEnumerable<Funcionario> funcionarios = await _dbConnection.QueryAsync<Funcionario>(sql);
            return funcionarios.ToList();
        }

        public async Task Update(Funcionario funcionario)
        {
            string sql = @"UPDATE Funcionario 
                              SET Nome = @Nome,
                                  Documento = @Documento,
                                  DataNascimento = @DataNascimento,
                                  Cargo = @Cargo,
                                  Salario = @Salario
                            WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { funcionario.Nome, funcionario.Documento, funcionario.DataNascimento, funcionario.Cargo, funcionario.Salario, funcionario.Id });
        }
    }
}