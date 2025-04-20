using Dapper;
using Hotelaria.Domain.Entities;
using Hotelaria.Infrastructure.Interfaces;
using System.Data;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IDbConnection _dbConnection;

        public async Task Add(Reserva reserva)
        {
            string sql = @"INSERT INTO Reserva (DataEntrada, DataSaida, ClienteId, QuartoId) 
                                        VALUES (@DataEntrada, @DataSaida, @ClienteId, @QuartoId)";
            await _dbConnection.ExecuteAsync(sql, new { DataEntrada = reserva.DataEntrada, DataSaida = reserva.DataSaida, ClienteId = reserva.Cliente.Id, QuartoId = reserva.Quarto.Id });
        }

        public async Task Delete(Reserva reserva)
        {
            string sql = @"DELETE FROM Reserva WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = reserva.Id });
        }

        public async Task<Reserva> GetById(Guid id)
        {
            string sql = "SELECT * FROM Reserva WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Reserva>(sql, new { Id = id });
        }

        public async Task Update(Reserva reserva)
        {
            string sql = @"UPDATE Reserva SET DataEntrada = @DataEntrada, DataSaida = @DataSaida, ClienteId = @ClienteId, QuartoId = @QuartoId 
                                        WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { DataEntrada = reserva.DataEntrada, DataSaida = reserva.DataSaida, ClienteId = reserva.Cliente.Id, QuartoId = reserva.Quarto.Id, Id = reserva.Id });
        }
    }
}
