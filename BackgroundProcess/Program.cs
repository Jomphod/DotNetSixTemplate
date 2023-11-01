// See https://aka.ms/new-console-template for more information

using Hangfire;
using Microsoft.Extensions.Configuration;

GlobalConfiguration.Configuration.UseSqlServerStorage(Configuration);

Console.WriteLine("Hello, World!");
