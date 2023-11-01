using Core.Interfaces.Infra.Helpers;
using Infra.Database.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.BackgroudService
{
    public class BackgroundServiceBase : BackgroundService
    {
        private IServiceProvider _serviceProvider;
        private readonly ILogger _logger;
        public BackgroundServiceBase(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }

        protected T GetService<T>()
        {
            return this._serviceProvider.GetRequiredService<T>();
        }

        public ILogger Logger
        {
            get
            {
                return _serviceProvider.GetService<ILogger>();
            }
        }

    }
}
