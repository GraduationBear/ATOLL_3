using Microsoft.AspNetCore.Components.WebView.Maui;
using ATOLL_3.Data;
using Syncfusion.Blazor;
namespace ATOLL_3;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjA1MjI2QDMyMzAyZTMxMmUzMFZnc09NYmYydFl2cStVT09lOFIzMHlIbzY2RHc0cS9Jdk1LT294eFJjUFk9");
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<Items>();
		builder.Services.AddSingleton<AntennaArray>();
		builder.Services.AddSingleton<Limites>();
		return builder.Build();
	}
}
