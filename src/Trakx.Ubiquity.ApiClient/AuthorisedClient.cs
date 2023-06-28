using Trakx.Common.ApiClient;

namespace Trakx.Ubiquity.ApiClient;

internal abstract class AuthorisedClient
{
#nullable disable
    public UbiquityApiConfiguration Configuration { get; protected set; }
#nullable restore

    private string? _baseUrl;
    protected string BaseUrl => _baseUrl ??= Configuration!.BaseUrl;

    protected readonly ICredentialsProvider CredentialProvider;

    protected AuthorisedClient(ClientConfigurator clientConfigurator)
    {
        Configuration = clientConfigurator.Configuration;
        CredentialProvider = clientConfigurator.GetCredentialsProvider();
    }
}
