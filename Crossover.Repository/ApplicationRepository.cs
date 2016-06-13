using System.Collections.Generic;
using System.Linq;
using Crossover.Core.Entity;
using Crossover.Core.IRepository;

namespace Crossover.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        public List<Application> GetApplication()
        {
            List<Application> application = new List<Application>();

            using (var db = new CrossoverEntities())
            {
                db.applications.ToList().ForEach(item =>
                {
                    application.Add(ConvertDBModelToDTOEntity(item));
                });

                return application;
            }
        }

        public Application GetApplication(string applicationId)
        {
            using (var db = new CrossoverEntities())
            {
                var application = db.applications.FirstOrDefault(item => item.application_id == applicationId);

                return ConvertDBModelToDTOEntity(application);
            }
        }

        public bool SaveApplication(Application entity)
        {
            ///TODO: Add validations before saving data
            try
            {
                using (var db = new CrossoverEntities())
                {
                    db.applications.Add(ConvertDTOEntityToDBModel(entity));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region Private Functions
        private Application ConvertDBModelToDTOEntity(application item)
        {
            Application app = new Application();

            if (item != null)
            {
                app.ApplicationId = item.application_id;
                app.DisplayName = item.display_name;
                app.Secret = item.secret;
            }

            return app;
        }

        private application ConvertDTOEntityToDBModel(Application item)
        {
            application app = new application();

            if (item != null)
            {
                app.application_id = item.ApplicationId;
                app.display_name = item.DisplayName;
                app.secret = item.Secret;
            }

            return app;
        }
        #endregion
    }
}

