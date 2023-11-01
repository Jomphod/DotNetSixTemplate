using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public abstract class ServiceBase : IDisposable
    {
        public ServiceBase()
        {
                
        }

        public void Dispose()
        {
            Dispose(dispose)
        }
    }
}
