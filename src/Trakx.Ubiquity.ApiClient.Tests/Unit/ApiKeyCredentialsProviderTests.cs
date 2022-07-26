using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using Trakx.Ubiquity.ApiClient.Utils;
using Xunit;

namespace Trakx.Ubiquity.ApiClient.Tests.Unit;

public sealed class ApiKeyCredentialsProviderTests : IDisposable
{
    private readonly ApiKeyCredentialsProvider _provider;

    public ApiKeyCredentialsProviderTests()
    {
        var options = new UbiquityApiConfiguration();
        options.ReturnsForAnyArgs(new UbiquityApiConfiguration {ApiKey = "pubKey"});
        _provider = new ApiKeyCredentialsProvider(options);
    }

    [Fact]
    public void AddCredentials_should_call_token_provider_and_add_authorisation_headers()
    {
        var message = new HttpRequestMessage { RequestUri = new Uri("https://test.com/test1/validate") };

        _provider.AddCredentials(message);

        message.Headers.Authorization!.Scheme.Should().Be(ApiKeyCredentialsProvider.JwtScheme);
        message.Headers.Authorization!.Parameter.Should().Be("pubKey");
    }

    public void Dispose()
    {
        _provider.Dispose();
    }
}
