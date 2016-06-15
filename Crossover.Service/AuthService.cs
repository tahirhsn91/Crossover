using Crossover.Core.Entity;
using Crossover.Core.IRepository;
using Crossover.Core.IService;

namespace Crossover.Service
{
    public class AuthService : IAuthService
    {
        private IApplicationRepository applicationRepository;

        public AuthService(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public Application GetApplication(string applicationId)
        {
            return this.applicationRepository.GetApplication(applicationId);
        }
    }
}
