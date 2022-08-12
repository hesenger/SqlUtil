using System;
using NUnit.Framework;

[assembly: CLSCompliant(true)]
namespace SqlUtil.Tests;

[SetUpFixture]
public static class TestsSetUp
{
    [OneTimeSetUp]
    public static void SetUp()
    {
    }
}