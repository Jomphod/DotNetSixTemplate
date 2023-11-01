using Core.Interfaces.Infra.Database;
using Core.Interfaces.Infra.Helpers;
using Core.Interfaces.Infra.ServiceLifetimes;
using Core.Interfaces.Services;
using Core.Services;
using Domain.Objects;
using Infra;
using Infra.BackgroudService;
using Infra.Database;
using Infra.Database.Helpers;
using Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WorkerService;

namespace WorkerService
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext(hostContext.Configuration);
                    //services.AddScoped<IDBHelper, DBHelper>();
                    //services.AddScoped<IQueryService, QueryService>();
                    //services.AddScoped<IQueryRepository, QueryRepository>();
                    services.AddOptions();
                    services.Configure<ConnectionStrings>(hostContext.Configuration.GetSection("ConnectionStrings"));
                    services.AddSingleton<DapperDBHelper>();
                    services.AddHostedService<Worker>();

                }).Build();

            await host.StartAsync();
        }

    }
}
