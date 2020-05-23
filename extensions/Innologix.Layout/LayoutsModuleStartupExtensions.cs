using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Piranha;
using Piranha.AspNetCore;

public static class LayoutsModuleStartupExtensions
{
    /// <summary>
    /// Uses the Innologix Layouts services if simple startup is used.
    /// </summary>
    /// <param name="serviceBuilder">The service builder</param>
    /// <returns>The updated builder</returns>
    public static PiranhaServiceBuilder AddLayoutModules(this PiranhaServiceBuilder serviceBuilder)
    {
        serviceBuilder.Services.AddLayoutModules();

        return serviceBuilder;
    }

    /// <summary>
    /// Uses the Innologix Layouts if simple startup is enabled.
    /// </summary>
    /// <param name="applicationBuilder">The application builder</param>
    /// <returns>The updated builder</returns>
    public static PiranhaApplicationBuilder UseLayoutModules(this PiranhaApplicationBuilder applicationBuilder)
    {
        applicationBuilder.Builder.UseLayoutModules();

        return applicationBuilder;
    }
}