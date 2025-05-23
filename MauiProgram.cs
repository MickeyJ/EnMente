﻿using EnMente.Services;
using Microsoft.Extensions.Logging;

namespace EnMente
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
                });

           
            builder.Services.AddMauiBlazorWebView();

#if ANDROID
            builder.Services.AddTransient<INotificationManagerService, EnMente.Platforms.Android.NotificationManagerService>();
#elif IOS
            builder.Services.AddTransient<INotificationManagerService, EnMente.Platforms.iOS.NotificationManagerService>();
#endif

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<ReminderService>();
            return builder.Build();
        }
    }
}
