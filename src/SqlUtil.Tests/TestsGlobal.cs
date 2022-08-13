using System;
using System.IO;
using System.Text.Json;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

[assembly: CLSCompliant(false)]
namespace SqlUtil.Tests;

[SetUpFixture]
public class TestsGlobal
{
    public static Settings? Settings { get; set; }

    [OneTimeSetUp]
    public void SetUp()
    {
        var settingsContent = File.ReadAllText(".settings.json");
        Settings = JsonSerializer.Deserialize<Settings>(settingsContent);

        var serviceProvider = CreateServices();
        using var scope = serviceProvider.CreateScope();
        UpdateDatabase(scope.ServiceProvider);
    }

    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
    }

    private static IServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer2016()
                .WithGlobalConnectionString(Settings!.ConnectionString)
                .ScanIn(typeof(TestsGlobal).Assembly).For.Migrations())
            .BuildServiceProvider(false);
    }
}