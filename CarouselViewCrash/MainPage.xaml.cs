using Mopups.Pages;
using Mopups.Services;
using System.Collections.ObjectModel;

namespace CarouselViewCrash
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnOpenPopupClicked(object sender, EventArgs e)
        {
            MopupService.Instance.PushAsync(new PopupPage());
        }
    }

}
