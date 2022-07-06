using BlueNotify.Services;
using BlueNotify.Views;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog;
using NLog.Web;

namespace BlueNotify
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
            var builder = MauiApp.CreateBuilder();
			builder.Logging.AddNLog("nlog.config");
            builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});
            DeclareServices(builder);
			DeclareView(builder);
            return builder.Build();
		}
		private static void DeclareServices(MauiAppBuilder builder)
        {
			builder.Services.AddSingleton<NotificationHubService>();
        }
        private static void DeclareView(MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<AppSettings>();
            builder.Services.AddSingleton<Explorer>();
        }
    }
}
