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

    [Fact(Skip = "This test is not working. Response: {'type':'no-endpoint','code':16387,'title':'No Such Endpoint','status':404,'detail':'No API endpoint is available at this path'}")]
    public async Task GetProtocolsAsync_should_work()
    {
        var response = await _client.GetProtocolsAsync();
        var protocolsOverview = response.Content;
        protocolsOverview.Should().NotBeNull();

        Logger.Information("retrieve protocols {protocols}", protocolsOverview);
    }

    [Fact]
    public async Task GetProtocolsListAsync_should_work()
    {
        var list = await _client.GetProtocolsListAsync();
        var protocolsOverview = list.Content;
        protocolsOverview.Should().NotBeNull();

        Logger.Information("retrieve protocols list {protocolsList}", protocolsOverview.Protocols);
    }
}
