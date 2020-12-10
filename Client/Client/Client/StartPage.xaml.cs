using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();

            var items = new List<SliderItem>()
            {
                new SliderItem() {Text = "A", ImageName = "slider_one"},
                new SliderItem() {Text = "B", ImageName = "slider_two"},
                new SliderItem() {Text = "C", ImageName = "slider_three", IsLast = true},
            };

            var names = new List<string>()
            {
                "A", "B", "C"
            };

            var images = new List<string>()
            {
                "slider_one", "slider_two", "slider_three"
            };
            CarouselView.ItemsSource = items;
        }
    }

    class SliderItem
    {
        public string Text { get; set; }
        public string ImageName { get; set; }
        public bool IsLast { get; set; }
    }
}