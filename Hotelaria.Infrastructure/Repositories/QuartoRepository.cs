using Dapper;
using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;
using System.Data;

namespace Hotelaria.Infrastructure.Repository
{
    public class QuartoRepository : IQuartoRepository
    {
        private readonly IDbConnection _dbConnection;

        public async Task Add(Quarto quarto)
        {
            string sql = @"INSERT INTO Quarto (Numero, MetrosQuadrados, Andar, NumeroComodos, NumeroCamas, EstaDisponivel, EstaLimpo, Preco) 
                                       VALUES (@Numero, @MetrosQuadrados, @Andar, @NumeroComodos, @NumeroCamas, @EstaDisponivel, @EstaLimpo, @Preco)";
            await _dbConnection.ExecuteAsync(sql, quarto);
        }

        public async Task Delete(Quarto quarto)
        {
            string sql = "DELETE FROM Quarto WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = quarto.Id });
        }

        public async Task<Quarto> GetById(int id)
        {
            string sql = "SELECT * FROM Quarto WHERE Id = @Id";
            Quarto quarto = await _dbConnection.QueryFirstOrDefaultAsync<Quarto>(sql, new { Id = id });
            return quarto;
        }

        public async Task<IEnumerable<Quarto>> GetAll()
        {
            string sql = "SELECT * FROM Quarto";
            IEnumerable<Quarto> quartos = await _dbConnection.QueryAsync<Quarto>(sql);
            return quartos.ToList();
        }

        public async Task Update(Quarto quarto)
        {
            string sql = @"UPDATE Quarto 
                              SET Numero = @Numero,
                                  MetrosQuadrados = @MetrosQuadrados,
                                  Andar = @Andar,
                                  NumeroComodos = @NumeroComodos,
                                  NumeroCamas = @NumeroCamas,
                                  EstaDisponivel = @EstaDisponivel,
                                  EstaLimpo = @EstaLimpo,
                                  Preco = @Preco
                            WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, quarto);
        }
    }
}
