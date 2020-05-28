using Innologix.Layout.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Piranha;

public static class LayoutModulesExtensions
{
    /// <summary>
    /// Adds the Innologix Layoutmodule.
    /// </summary>
    /// <param name="services">The current service collection</param>
    /// <param name="configure">The optional api configuration</param>
    /// <returns>The services</returns>
    public static IServiceCollection AddLayoutModules(this IServiceCollection services)
    {
        App.Modules.Register<Module>();

        // Return the service collection
        return services;
    }

    /// <summary>
    /// Uses the Piranha Manager if simple startup is enabled.
    /// </summary>
    /// <param name="applicationBuilder">The application builder</param>
    /// <returns>The updated builder</returns>
    public static IApplicationBuilder UseLayoutModules(this IApplicationBuilder builder)
    {
        // Manager resources
        App.Modules.Manager().Scripts
           .Add("~/manager/assets/js/innologix.contentedit.js");

        App.Modules.Manager().Styles
            .Add("~/manager/assets/css/innologix.layouts.min.css");

        return builder.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new EmbeddedFileProvider(typeof(LayoutModulesExtensions).Assembly, "Innologix.Layouts.assets.dist"),
            RequestPath = "/manager/assets"
        });
    }
}
