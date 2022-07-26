using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Trakx.Ubiquity.ApiClient.Tests.Integration;

public class ProtocolsClientTests : UbiquityClientTestsBase
{
    private readonly IProtocolsClient _client;

    public ProtocolsClientTests(UbiquityApiFixture apiFixture, ITestOutputHelper output)
        : base(apiFixture, output)
    {
        _client = ServiceProvider.GetRequiredService<IProtocolsClient>();
    }

    [Fact]
    public async Task GetProtocolsAsync_should_work()
    {
        var response = await _client.GetProtocolsAsync();
        var protocolsOverview = response.Result;
        protocolsOverview.Should().NotBeNull();

        Logger.Information("retrieve protocols {protocols}", protocolsOverview);
    }

    [Fact]
    public async Task GetProtocolsListAsync_should_work()
    {
        var list = await _client.GetProtocolsListAsync();
        var protocolsOverview = list.Result;
        protocolsOverview.Should().NotBeNull();

        Logger.Information("retrieve protocols list {protocolsList}", protocolsOverview.Protocols);
    }
}
