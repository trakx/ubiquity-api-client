using Trakx.Common.ApiClient;
using Trakx.Ubiquity.ApiClient.Utils;

namespace Trakx.Ubiquity.ApiClient;

internal class ClientConfigurator
{
    private readonly IUbiquityCredentialsProvider _credentialsProvider;

    public ClientConfigurator(UbiquityApiConfiguration configuration, IUbiquityCredentialsProvider credentialsProvider)
    {
        _credentialsProvider = credentialsProvider;
        Configuration = configuration;
    }

    public UbiquityApiConfiguration Configuration { get; }

    public ICredentialsProvider GetCredentialsProvider()
    {
        return _credentialsProvider;
    }
}
