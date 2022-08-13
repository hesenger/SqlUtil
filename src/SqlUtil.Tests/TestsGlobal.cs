using System;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

[assembly: CLSCompliant(true)]
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
    }
}