using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Trakx.Ubiquity.ApiClient.Utils;
using Trakx.Utils.Apis;

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
