using FluentAssertions.Execution;
using Trakx.Common.Infrastructure.Environment.Env;
using Xunit.Abstractions;

namespace Trakx.Ubiquity.ApiClient.Tests.Integration;

public class OpenApiGeneratedCodeModifier : Common.Testing.Documentation.OpenApiGeneratedCodeModifier
{
    public OpenApiGeneratedCodeModifier(ITestOutputHelper output)
        : base(output)
    {
        var foundRoot = default(DirectoryInfo).TryWalkBackToRepositoryRoot(out var rootDirectory)!;
        if (!foundRoot) throw new AssertionFailedException("Failed to retrieve repository root.");
        FilePaths.Add(Path.Combine(rootDirectory!.FullName, "src",
            "Trakx.Ubiquity.ApiClient", "ApiClients.cs"));
    }
}