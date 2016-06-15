using Crossover.Core.Entity;
using Crossover.Core.IRepository;
using Crossover.Core.IService;
using System;
using System.Collections.Generic;

namespace Crossover.Service
{
    public class RegisterService : IRegisterService
    {
        private IApplicationRepository applicationRepository;

        public RegisterService(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public Application Register(Application entity)
        {
            entity.ApplicationId = Guid.NewGuid().ToString().Replace("-", "");
            if (entity.ApplicationId.Length > 25)
            {
                entity.ApplicationId = entity.ApplicationId.Substring(0, 24);
            }

            entity.Secret = entity.ApplicationId;

            this.applicationRepository.SaveApplication(entity);

            return entity;
        }
    }
}
