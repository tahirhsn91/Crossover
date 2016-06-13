using Crossover.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossover.Core.IService
{
    public interface ILogService
    {
        bool SaveLog(Log entity);
    }
}
