using Crossover.Core.Entity;
using Crossover.Core.IRepository;

namespace Crossover.Repository
{
    public class LogRepository : ILogRepository
    {
        public bool SaveLog(Log entity)
        {
            ///TODO: Add validations before saving data
            try
            {
                using (var db = new CrossoverEntities())
                {
                    db.logs.Add(ConvertDTOEntityToDBModel(entity));
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private log ConvertDTOEntityToDBModel(Log item)
        {
            log obj = new log();

            if (item != null)
            {
                obj.logger = item.Logger;
                obj.level = item.Level;
                obj.message = item.Message;
                obj.application_id = item.ApplicationId;
            }

            return obj;
        }
    }
}
