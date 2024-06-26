using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using System.Collections.ObjectModel;

namespace CarouselViewCrash
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMauiHandlers(RegisterRenderers)
                .ConfigureMopups()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void RegisterRenderers(IMauiHandlersCollection handlersCollection)
        {
            handlersCollection.AddHandler(typeof(CarouselView), typeof(CarouselViewCrash.Platforms.iOS.CarouselViewHandler));
            handlersCollection.AddHandler(typeof(Button), typeof(CarouselViewCrash.Platforms.iOS.MyButtonHandler));
        }
    }
}
