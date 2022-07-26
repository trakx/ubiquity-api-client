
using Serilog;
using Xunit.Abstractions;

namespace Trakx.Ubiquity.ApiClient.Tests.Unit;

public class CredentialsTestsBase
{
    protected ILogger Logger;
    protected UbiquityApiConfiguration Configuration { get; }

    protected CredentialsTestsBase(ITestOutputHelper output)
    {
        Logger = new LoggerConfiguration().WriteTo.TestOutput(output).CreateLogger();
        Configuration = new UbiquityApiConfiguration
        {
            BaseUrl = "https://api.ubiquity.io/v1",
            ApiKey = "pubKey"
        };
    }
}
