#pragma warning disable S1172, IDE0060 // Unused method parameters should be removed

namespace Trakx.Ubiquity.ApiClient
{
    internal partial class AccountsClient
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            CredentialProvider.AddCredentials(request);
        }
    }
    internal partial class Block_IdentifiersClient
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            CredentialProvider.AddCredentials(request);
        }
    }
    internal partial class BlocksClient
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            CredentialProvider.AddCredentials(request);
        }
    }
    internal partial class NFTClient
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            CredentialProvider.AddCredentials(request);
        }
    }
    internal partial class ProtocolsClient
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            CredentialProvider.AddCredentials(request);
        }
    }
    internal partial class SyncClient
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            CredentialProvider.AddCredentials(request);
        }
    }
    internal partial class TransactionsClient
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            CredentialProvider.AddCredentials(request);
        }
    }

}
