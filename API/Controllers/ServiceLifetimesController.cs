using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Interfaces.Infra.ServiceLifetimes;

namespace API.Controllers
{
    [Route("[controller]")]
    public class ServiceLifetimesController : ControllerBase
    {
        private readonly ITransientService _transientService;
        private readonly ITransientService _transientServiceTwo;
        private readonly ITransientService _transientServiceThree;
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;

        public ServiceLifetimesController(
            ITransientService transientService,
            ITransientService transientServiceTwo,
            ITransientService transientServiceThree,
            IScopedService scopedService,
            ISingletonService singletonService)
        {
            this._transientService = transientService;
            this._transientServiceTwo = transientServiceTwo;
            this._transientServiceThree = transientServiceThree;

            this._scopedService = scopedService;
            this._singletonService = singletonService;
        }

        public class GetServiceLifeTimesPOCResult {
            public GetServiceLifeTimesPOCResultGetInstantConstructionTime Transient { get; set; }
            public GetServiceLifeTimesPOCResultGetInstantConstructionTime TransientTwo { get; set; }
            public GetServiceLifeTimesPOCResultGetInstantConstructionTime TransientThree { get; set; }
            public int Scoped { get; set; }
            public int Singleton { get; set; }
        }

        public class GetServiceLifeTimesPOCResultGetInstantConstructionTime {
            public int Transient { get; set; }
            public int Scoped { get; set; }
            public int Singleton { get; set; }
        }

        [HttpGet(Name = "GetServiceLifeTimesPOC")]
        public GetServiceLifeTimesPOCResult GetServiceLifeTimesPOC(){
            
            return new GetServiceLifeTimesPOCResult(){

                Transient = new GetServiceLifeTimesPOCResultGetInstantConstructionTime(){
                    Transient = _transientService.GetRequestedCount(),
                    Scoped = _transientService.GetScopedRequestCount(),
                    Singleton = _transientService.GetSingletionRequestCount()
                },

                TransientTwo = new GetServiceLifeTimesPOCResultGetInstantConstructionTime(){
                    Transient = _transientServiceTwo.GetRequestedCount(),
                    Scoped = _transientServiceTwo.GetScopedRequestCount(),
                    Singleton = _transientServiceTwo.GetSingletionRequestCount()
                },

                TransientThree = new GetServiceLifeTimesPOCResultGetInstantConstructionTime(){
                    Transient = _transientServiceThree.GetRequestedCount(),
                    Scoped = _transientServiceThree.GetScopedRequestCount(),
                    Singleton = _transientService.GetSingletionRequestCount()
                },

                Scoped = _scopedService.GetRequestedCount(),
                Singleton = _singletonService.GetRequestedCount()
            };

        }
    }
}