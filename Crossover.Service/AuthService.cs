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

        public string GetAuthToken(string applicationId)
        {
            return null;
        }
    }
}
