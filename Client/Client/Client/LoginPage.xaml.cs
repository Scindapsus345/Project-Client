using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            OpenSlider();
        }

        private async void OpenSlider()
        {
            await Navigation.PushAsync(new StartPage());
        }

        private async void TryLogin(object sender, EventArgs e)
        {
            var data = new AuthenticationData(login.Text, password.Text);
            var jsonData = JsonConvert.SerializeObject(data);
            try
            {
                HttpResponseMessage response = await App.Client.PostAsync("https://soulfire.westus.cloudapp.azure.com/authenticate", new StringContent(jsonData));
                response.EnsureSuccessStatusCode();
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            catch
            {
                login.Text = "AAAAAAAA";
            }
        }

        private async void OpenRegistration(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new RegistrationPage(), this);
            await Navigation.PopAsync();
        }
    }

    class AuthenticationData
    {
        public string login { get; set; }
        public string password { get; set; }

        public AuthenticationData(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}