using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarouselViewCrash
{
    internal class PaginationPage
    {
        public ObservableCollection<string> Children { get; set; } = new ObservableCollection<string>() { "hello", "world", "How", "are", "You", "world", "How", "are", "You", "world", 
            "How", "are", "You", "world", "How", "are", "You", "world", "How", "are", "You", "world", "How", "are", "You", "world", "How", "are", "You"};
    }
}
