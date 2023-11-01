using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.ServiceLifetimes;

namespace Infra.ServiceLifetimes
{
    public class TransientService : ITransientService
    {
        private int _requestedCount;
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;
        public TransientService(IScopedService scopedService, ISingletonService singletonService){
            this._scopedService = scopedService;
            this._singletonService = singletonService;
        }
        public int GetRequestedCount(){
            _requestedCount += 1;
            return _requestedCount;
        }

        public int GetScopedRequestCount() => this._scopedService.GetRequestedCount();
        public int GetSingletionRequestCount() => this._singletonService.GetRequestedCount();
    }
}