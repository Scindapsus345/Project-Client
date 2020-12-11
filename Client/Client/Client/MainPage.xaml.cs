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
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            OpenSlider();
            CurrentPage = fire_content;
        }
        private async void OpenSlider()
        {
            await Navigation.PushAsync(new StartPage());
        }

    }
}