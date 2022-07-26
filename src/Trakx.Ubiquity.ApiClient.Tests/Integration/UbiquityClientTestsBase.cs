using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Trakx.Utils.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Trakx.Ubiquity.ApiClient.Tests.Integration;

[Collection(nameof(ApiTestCollection))]
public class UbiquityClientTestsBase
{
    protected readonly ServiceProvider ServiceProvider;
    protected ILogger Logger;

    protected UbiquityClientTestsBase(UbiquityApiFixture apiFixture, ITestOutputHelper output)
    {
        Logger = new LoggerConfiguration().WriteTo.TestOutput(output).CreateLogger();

        ServiceProvider = apiFixture.ServiceProvider;
    }
}

[CollectionDefinition(nameof(ApiTestCollection))]
public class ApiTestCollection : ICollectionFixture<UbiquityApiFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}

public class UbiquityApiFixture : IDisposable
{
    public readonly ServiceProvider ServiceProvider;

    public UbiquityApiFixture()
    {
        var configuration = ConfigurationHelper.GetConfigurationFromAws<UbiquityApiConfiguration>("CiCd", true)
            with
            {
                BaseUrl = "https://ubiquity.api.blockdaemon.com/",
            };

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton(configuration);
        serviceCollection.AddUbiquityClient(configuration);

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;
        ServiceProvider.Dispose();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
