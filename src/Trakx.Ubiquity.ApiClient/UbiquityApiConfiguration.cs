using Trakx.Common.Attributes;

namespace Trakx.Ubiquity.ApiClient;

public record UbiquityApiConfiguration
{
#nullable disable
    public string BaseUrl { get; set; }

    [AwsParameter, SecretEnvironmentVariable]
    public string ApiKey { get; init; }
#nullable restore
}
