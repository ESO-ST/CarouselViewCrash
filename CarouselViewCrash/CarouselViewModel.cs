using System.Collections.ObjectModel;

namespace CarouselViewCrash
{
    internal class CarouselViewModel
    {
        private ObservableCollection<object> myItems = new ObservableCollection<object>() { new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage(), new PaginationPage() };
        public ObservableCollection<object> Items => myItems;
    }
}
