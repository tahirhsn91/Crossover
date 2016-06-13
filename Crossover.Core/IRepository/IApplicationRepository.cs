using System.Collections.Generic;
using Crossover.Core.Entity;

namespace Crossover.Core.IRepository
{
    public interface IApplicationRepository
    {
        List<Application> GetApplication();

        Application GetApplication(string applicationId);

        bool SaveApplication(Application entity);
    }
}
