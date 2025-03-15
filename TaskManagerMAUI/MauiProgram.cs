using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using TaskManagerMAUI.Services;

namespace TaskManagerMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

        // Load appsettings.json how resource
        var assembly = Assembly.GetExecutingAssembly();
        try
        {
            using var stream = assembly.GetManifestResourceStream("TaskManagerMAUI.Resources.Raw.appsettings.json");
            if (stream == null)
            {
                throw new FileNotFoundException("appsettings.json not found in embedded resources.");
            }

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);
        }
        catch (Exception ex)
        {
            // Log the exception and handle it appropriately
            Console.WriteLine($"Error loading configuration: {ex.Message}");
        }

        builder.Services.AddSingleton<ITokenService, TokenService>();
		builder.Services.AddSingleton<IShareTaskService, ShareTaskService>();
        builder.Services.AddSingleton<ILoadTaskService, LoadTaskService>();
        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
