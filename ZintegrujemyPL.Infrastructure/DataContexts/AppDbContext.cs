using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.DataContexts;

namespace ZintegrujemyPL.ZadanieTestowe.Infrastructure.Data
{

    public class AppDbContext : IAppDbContext
    {
        private readonly string _connectionString;


        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<T> QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
            }
        }

        public async Task<int> Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
