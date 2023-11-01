using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Infra.ServiceLifetimes
{
    public interface ISingletonService
    {
        public int GetRequestedCount();
    }
}