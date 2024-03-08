using System.Threading.Tasks;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.DataContexts
{
    public interface IAppDbContext
    {
        Task<T> QueryFirstOrDefault<T>(string sql, object parameters = null);
        Task<int> Execute(string sql, object parameters = null);
    }
}
