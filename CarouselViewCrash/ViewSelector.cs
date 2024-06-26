using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarouselViewCrash
{
    internal class ViewSelector : DataTemplateSelector
    { 
        // TODO: Add new DataTemplates to Dictionary. Cache them and reuse.

        // TODO: Having trouble with references to baseDomainModel. Replacing a single DataTemplate
        // for now, but need to look at the consequences of doing so.
        //private readonly IDictionary<Type, DataTemplate> DataTemplates;
        private DataTemplate DataTemplate;

        public ViewSelector()
        {
            DataTemplate = new DataTemplate();
        }

        // Note: BindingContext is set by the data template when a data template is found in the dictionary.
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new DataTemplate(() => new Button() { Text = $"Button {Random.Shared.NextSingle()}", Command = new Command(_ => Console.WriteLine("Button Clicked")) });
        }
    }
}
