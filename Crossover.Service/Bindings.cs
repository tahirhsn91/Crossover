using System;
using Ninject.Modules;
using Crossover.Core.IRepository;
using Crossover.Repository;

namespace Crossover.Service
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplicationRepository>().To<ApplicationRepository>();
        }
    }
}
