using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Trakx.Utils.DateTimeHelpers;
using Trakx.Ubiquity.ApiClient.Utils;

namespace Trakx.Ubiquity.ApiClient;

public static partial class AddUbiquityClientExtension
{
    public static IServiceCollection AddUbiquityClient(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.Configure<UbiquityApiConfiguration>(
            configuration.GetSection(nameof(UbiquityApiConfiguration)));
        AddCommonDependencies(services);

        return services;
    }

    public static IServiceCollection AddUbiquityClient(
        this IServiceCollection services, UbiquityApiConfiguration apiConfiguration)
    {
        services.AddSingleton(apiConfiguration);

        AddCommonDependencies(services);

        return services;
    }

    private static void AddCommonDependencies(IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IUbiquityCredentialsProvider, ApiKeyCredentialsProvider>();

        services.AddSingleton<ClientConfigurator>();
        AddClients(services);
    }
}
