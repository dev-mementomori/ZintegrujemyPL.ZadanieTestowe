using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Base;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.DataContexts;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories;

namespace ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        public IAppDbContext _appDbContext;
        public Repository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
