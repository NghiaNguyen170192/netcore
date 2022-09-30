﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.Infrastructure.Database;
using NetCore.Shared.Extensions;
using System;
using System.Threading.Tasks;
using NetCore.Shared.Configurations;
using NetCore.Migration.Extensions;
using NetCore.Infrastructure.Database.Repositories;
using System.Reflection;
using MediatR;
using AutoMapper.Configuration;

namespace NetCore.Migration;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using var scope = host.Services.CreateScope();
        try
        {
            var application = scope.ServiceProvider.GetRequiredService<MigrationService>();
            await application.RunAsync(args);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return;
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseEnvironment(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
            .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) => configurationBuilder.AddAppSettings(hostBuilderContext, args))
            .ConfigureServices((hostBuilderContext, services) =>
            {
                var databaseConfiguration = new DatabaseConfiguration();
                hostBuilderContext.Configuration.GetSection("Database").Bind(databaseConfiguration);

                services.AddDbContext<DatabaseContext>(builder =>
                {
                    builder.UseSqlServer(databaseConfiguration.ApplicationConnectionString, o => o.MigrationsAssembly(databaseConfiguration.MigrationsAssembly));
                });

                services.AddScoped<MigrationService>();
                services.RegisterMigrationTasks(); // DI for migration task
                services.RegisterSeeds(); // DI for seeds on SeedDataTask
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                services.AddMediatR(typeof(Application.AssemblyReference).GetTypeInfo().Assembly);
                
                //caching
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = hostBuilderContext.Configuration.GetValue<string>("Redis:ConnectionString");
                });
            })
            .AddLoggingConfiguration("netcore-migration-logs");
    }
}
