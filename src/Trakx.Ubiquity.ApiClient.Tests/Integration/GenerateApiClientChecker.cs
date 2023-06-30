using Trakx.Common.Testing.Documentation.GenerateApiClient;
using Xunit.Abstractions;

namespace Trakx.Ubiquity.ApiClient.Tests.Integration;

public class GenerateApiClientChecker : GenerateApiClientCheckerBase
{
    public GenerateApiClientChecker(ITestOutputHelper output)
        : base(output, CreateProjectFileFinder())
    {
    }

    private static IProjectFileFinder CreateProjectFileFinder()
    {
        var objectFromClientAssembly = new UbiquityApiConfiguration();
        var currentDirectory = Environment.CurrentDirectory;
        return new ProjectFileFinder(objectFromClientAssembly, currentDirectory);
    }
}