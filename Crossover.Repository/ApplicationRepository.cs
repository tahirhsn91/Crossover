using System.Collections.Generic;
using System.Linq;
using Crossover.Core.Entity;
using Crossover.Core.IRepository;
using System;

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
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Private Functions
        private Application ConvertDBModelToDTOEntity(application item)
        {
            Application obj = new Application();

            if (item != null)
            {
                obj.ApplicationId = item.application_id;
                obj.DisplayName = item.display_name;
                obj.Secret = item.secret;
            }

            return obj;
        }

        private application ConvertDTOEntityToDBModel(Application item)
        {
            application obj = new application();

            if (item != null)
            {
                obj.application_id = item.ApplicationId;
                obj.display_name = item.DisplayName;
                obj.secret = item.Secret;
            }

            return obj;
        }
        #endregion
    }
}

