using Crossover.Core.Entity;
using Crossover.Core.IRepository;
using Crossover.Core.IService;
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

        public void Register(Application entity)
        {
            this.applicationRepository.SaveApplication(entity);
        }

        public List<Application> GetApplication()
        {
            return this.applicationRepository.GetApplication();
        }
    }
}
