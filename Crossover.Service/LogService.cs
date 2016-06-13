using Crossover.Core.Entity;
using Crossover.Core.IRepository;
using Crossover.Core.IService;

namespace Crossover.Service
{
    public class LogService : ILogService
    {
        private ILogRepository logRepository;

        public LogService(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public bool SaveLog(Log entity)
        {
            try
            {
                return this.logRepository.SaveLog(entity);
            }
            catch
            {
                return false;
            }
        }
    }
}
