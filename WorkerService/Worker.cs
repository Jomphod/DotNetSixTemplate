using Core.Interfaces.Infra.Helpers;
using Core.Interfaces.Infra.ServiceLifetimes;
using Core.Interfaces.Services;
using Core.Services;
using Infra.BackgroudService;
using Infra.Database;
using Infra.Database.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WorkerService
{
    public class Worker : BackgroundServiceBase
    {
        private IQueryService _queryService;
        private DapperDBHelper _dbService;
        public Worker(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            //this._queryService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IQueryService>();

        }

        //public IQueryService QueryService
        //{
        //    get
        //    {
        //        if(this._queryService == null)
        //            this._queryService = this.GetService<IQueryService>();
        //        return this._queryService;
        //    }
        //}

        public DapperDBHelper DBHelper
        {
            get
            {
                if (this._dbService == null)
                    this._dbService = this.GetService<DapperDBHelper>();
                return this._dbService;
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) 
            {
                var x = this.DBHelper.Query("select * from provinces");



                //Logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}