using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Trakx.Ubiquity.ApiClient.Utils;
using Trakx.Utils.Apis;

namespace Trakx.Ubiquity.ApiClient;

internal class ClientConfigurator
{
    private readonly IServiceProvider _provider;

    public ClientConfigurator(IServiceProvider provider)
    {
        _provider = provider;
        Configuration = provider.GetService<IOptions<UbiquityApiConfiguration>>()!.Value;
    }

    public UbiquityApiConfiguration Configuration { get; }

    public ICredentialsProvider GetCredentialsProvider()
    {
        return _provider.GetRequiredService<IUbiquityCredentialsProvider>();
    }
}
