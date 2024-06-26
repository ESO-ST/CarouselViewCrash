namespace CarouselViewCrash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselView : ContentView
    {
        public CarouselView()
        {
            InitializeComponent();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (carouselView != null)
            {
                carouselView.Position = 0;
            }
        }

        protected override void OnParentChanged()
        {
            base.OnParentChanged();

            if (carouselView != null)
            {
                if (DeviceDisplay.Current.MainDisplayInfo.Orientation == DisplayOrientation.Portrait)
                {
                    carouselView.WidthRequest = 659;
                }
                else
                {
                    carouselView.WidthRequest = 929;
                }
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (carouselView != null)
            {
                carouselView.WidthRequest = width;
                carouselView.HeightRequest = height;
            }
        }
    }
}