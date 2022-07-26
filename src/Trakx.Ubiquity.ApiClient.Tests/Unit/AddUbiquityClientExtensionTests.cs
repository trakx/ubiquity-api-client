using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Trakx.Ubiquity.ApiClient.Tests.Unit;

public class AddUbiquityClientExtensionTests : CredentialsTestsBase
{
    public AddUbiquityClientExtensionTests(ITestOutputHelper output)
        : base(output)
    { }

    [Fact]
    public void Services_should_be_built()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddUbiquityClient(Configuration);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var client = serviceProvider.GetRequiredService<IProtocolsClient>();
        client.Should().NotBeNull();
    }
}
