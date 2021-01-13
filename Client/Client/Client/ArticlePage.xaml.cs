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
    public partial class ArticlePage : ContentPage
    {
        public ArticlePage(bool isFavorite = false)
        {
            InitializeComponent();
            markBtn.IsVisible = !isFavorite;
        }

        public async void Save(object sender, EventArgs e)
        {
            await DisplayAlert("", "Статья успешно добавленна в избранное", "Ок");
        }
    }
}