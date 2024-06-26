using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarouselViewCrash.Platforms.iOS
{
    internal class CarouselViewHandler : ContentViewHandler
    {
        protected override async void ConnectHandler(Microsoft.Maui.Platform.ContentView platformView)
        {
            base.ConnectHandler(platformView);

            await Task.Delay(1);   // Delay is required for displaying Carousel Items.
        }
    }
}
