using System.Net.Http.Headers;
using Serilog;
using Trakx.Common.ApiClient;

namespace Trakx.Ubiquity.ApiClient.Utils;

public interface IUbiquityCredentialsProvider : ICredentialsProvider { };

public sealed class ApiKeyCredentialsProvider : IUbiquityCredentialsProvider, IDisposable
{
    internal const string JwtScheme = "Bearer";

    private readonly UbiquityApiConfiguration _configuration;
    private readonly CancellationTokenSource _tokenSource;

    private static readonly ILogger Logger = Log.Logger.ForContext<ApiKeyCredentialsProvider>();

    public ApiKeyCredentialsProvider(UbiquityApiConfiguration configuration)
    {
        _configuration = configuration;

        _tokenSource = new CancellationTokenSource();
    }


    #region Implementation of ICredentialsProvider

    /// <inheritdoc />
    public void AddCredentials(HttpRequestMessage msg)
    {
        msg.Headers.Authorization = new AuthenticationHeaderValue(JwtScheme, _configuration.ApiKey);
        Logger.Verbose("Headers added");
    }

    public Task AddCredentialsAsync(HttpRequestMessage msg)
    {
        AddCredentials(msg);
        return Task.CompletedTask;
    }

    #endregion

    #region IDisposable

    private void Dispose(bool disposing)
    {
        if (!disposing) return;
        _tokenSource.Cancel();
        _tokenSource.Dispose();
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
