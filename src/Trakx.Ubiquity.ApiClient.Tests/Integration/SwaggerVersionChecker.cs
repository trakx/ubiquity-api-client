using System.Text.RegularExpressions;
using FluentAssertions;
using Flurl.Http;
using Trakx.Common.Infrastructure.Environment.Env;
using Xunit;

namespace Trakx.Ubiquity.ApiClient.Tests.Integration;

public class SwaggerVersionChecker : IDisposable
{
    private readonly IFlurlClient _ubiquityClient;

    public SwaggerVersionChecker()
    {
        _ubiquityClient = new FlurlClient("https://docs.ubiquity.com");
    }

    [Fact(Skip = "local openapi file was changed to improve methods signature and fix nullable issues. After that, this test is no longer working, as it takes the assumption that both files, local and remote, are identical.")]
    //[Fact]
    public async Task VerifyOpenApiVersion()
    {
        var apiResponse = await _ubiquityClient.Request("api", "v1", "swagger").SendAsync(HttpMethod.Get);
        var ubiquityOpenApi = await apiResponse.GetStringAsync();
        var modifiedOpenApi = GetCurrentOpenApi();

        var ubiquityRawOpenApi = Regex.Replace(ubiquityOpenApi, @"\s+", string.Empty);
        var unmodifiedOpenAPi = Regex.Replace(modifiedOpenApi, @"tags\: \[[A-Za-z]{2,}\](\r?\n)", string.Empty);
        unmodifiedOpenAPi = Regex.Replace(unmodifiedOpenAPi, @"operationId\: [A-Za-z]{2,}(\r?\n)", string.Empty);
        var currentRawOpenApi = Regex.Replace(unmodifiedOpenAPi, @"\s+", string.Empty);
        currentRawOpenApi = Regex.Replace(currentRawOpenApi, "-FTX", string.Empty);

        ubiquityRawOpenApi.Should().Be(currentRawOpenApi);
    }


    private static string GetCurrentOpenApi()
    {
        var isRootDirectory = EnvExtensions.TryWalkBackToRepositoryRoot(null, out var rootDirectory);
        if (!isRootDirectory || rootDirectory == null)
            return "";

        var openApiPath = Path.Combine(rootDirectory.ToString(), "src", "Trakx.Ubiquity.ApiClient", "openApi3.yaml");
        return File.ReadAllText(openApiPath);
    }

    public void Dispose()
    {
        _ubiquityClient.Dispose();
    }
}
