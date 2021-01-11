using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : CarouselPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void ToLoginPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}