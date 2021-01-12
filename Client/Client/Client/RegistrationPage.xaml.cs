using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void TryRegister(object sender, EventArgs e)
        {
            if (password.Text != pswdConfirm.Text)
            {
                errorLog.Text = "Пароли не совпадают";
                return;
            }
            var data = new RegistrationData(login.Text, email.Text, password.Text, name.Text);
            var jsonData = JsonConvert.SerializeObject(data);
            try
            {
                HttpResponseMessage response = await App.Client.PostAsync("https://soulfire.westus.cloudapp.azure.com/register", new StringContent(jsonData));
                response.EnsureSuccessStatusCode();
                Navigation.InsertPageBefore(new QuestionsPage(), this);
                await Navigation.PopAsync();
            }
            catch
            {
                login.Text = "AAAAAAAA";
            }
        }
    }

    class RegistrationData
    {
        public string login { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string birth_date  { get; set; }
        public string registration_date { get; set; }

        public RegistrationData(string login, string email, string password, string first_name)
        {
            this.login = login;
            this.email = email;
            this.password = password;
            this.first_name = first_name;
            last_name = "";
            registration_date = "2020-10-10 15:48:33";
            birth_date = "2020-10-10 15:48:33";
        }
    }
}