using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework.Diagnostics;
using Testcontainers.MsSql;

namespace CustomerService.Tests;

[SetUpFixture]
public class FixtureClass {
    private static MsSqlContainer? _msSqlContainer;

    [OneTimeSetUp]
    public static async Task OneTimeSetup() {
        // I've tested adding this, but it doesn't seem to make any difference
        //if (!Trace.Listeners.OfType<ProgressTraceListener>().Any())
        //    Trace.Listeners.Add(new ProgressTraceListener());

        _msSqlContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-CU10-ubuntu-22.04")
            .WithEnvironment(new Dictionary<string, string> {
                { "ACCEPT_EULA", "Y" },
                { "MSSQL_PID", "Developer" }
            })
            .Build();

        await _msSqlContainer.StartAsync();
    }

    [OneTimeTearDown]
    public static async Task OneTimeTearDown() {
        await _msSqlContainer.DisposeAsync();
    }

}
