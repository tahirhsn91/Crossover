using Crossover.Core.Entity;

namespace Crossover.Core.IService
{
    public interface IAuthService
    {
        Application GetApplication(string applicationId);
    }
}
