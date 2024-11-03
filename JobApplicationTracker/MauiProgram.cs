using JobApplicationTracker.Infrastructure.Persistence;
using JobApplicationTracker.ViewModel;
using Microsoft.Extensions.Logging;

namespace JobApplicationTracker
{
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

            builder.Services.AddScoped<LocalDbService>();
            builder.Services.AddScoped<MainPage>();
            builder.Services.AddScoped<MainViewModel>();
            builder.Services.AddScoped<TrackingService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
