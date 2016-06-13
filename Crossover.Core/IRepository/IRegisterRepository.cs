using Crossover.Core.Entity;

namespace Crossover.Core.IRepository
{
    public interface ILogRepository
    {
        bool SaveLog(Log entity);
    }
}
