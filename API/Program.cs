using Microsoft.EntityFrameworkCore;
using Core.Interfaces.Infra.ServiceLifetimes;
using Core.Interfaces.Infra.Email;
using Infra.ServiceLifetimes;
using Infra.Database;
using Infra.Email;
using Core.Interfaces.Services;
using Core.Interfaces.Infra.Database;
using Infra.Database.Repositories;
using Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterLifeTimeServicesExtensions();
builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<MailGunEmailProviderOption>(builder.Configuration.GetSection(MailGunEmailProviderOption.ConfigItem));
builder.Services.Configure<SendgridEmailProviderOption>(builder.Configuration.GetSection(SendgridEmailProviderOption.ConfigItem));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await SeedDatabase();

app.Run();

async Task SeedDatabase(){
    using(var scope = app.Services.CreateScope()){
        var dbcontext = scope.ServiceProvider.GetRequiredService<DataContext>();
        await dbcontext.Database.MigrateAsync(); // Run script migration
        await Infra.Database.Seed.SeedData(dbcontext); // Seed data to the project
    }
}


