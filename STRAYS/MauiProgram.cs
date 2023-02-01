using STRAYS.Data;
using STRAYS.Services;
using STRAYS.ViewModels;
using STRAYS.Views;

namespace STRAYS;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        string dbPath = FileAccessHelper.GetLocalFilePath("burger.db3");
        builder.Services.AddSingleton<DatabaseActions>(s => ActivatorUtilities.CreateInstance<DatabaseActions>(s, dbPath));
        builder.Services.AddSingleton<ImageGenerator>(s => ActivatorUtilities.CreateInstance<ImageGenerator>(s));
		builder.Services.AddSingleton<PaePage>();
        builder.Services.AddSingleton<PaeViewModel>();
        builder.Services.AddSingleton<AlertaPage>();
        builder.Services.AddSingleton<AlertaViewModel>();
        return builder.Build();
	}
}
