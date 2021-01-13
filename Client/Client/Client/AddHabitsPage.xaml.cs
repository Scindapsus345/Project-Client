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
    public partial class AddHabitsPage : ContentPage
    {
        private Habit[] habits;
        private CheckBox[] checkBoxes;
        private HomePage homePage;
        public AddHabitsPage(Habit[] habits, HomePage homePage)
        {
            InitializeComponent();
            this.habits = habits;
            this.homePage = homePage;
            InitializeCheckBoxes();
            ShowHabits();
        }

        private void InitializeCheckBoxes()
        {
            checkBoxes = new CheckBox[13];
            for (var i = 0; i < habits.Length; i++)
            {
                checkBoxes[i] = new CheckBox()
                {
                    Color = Color.FromHex("#00FF0A"),
                    HorizontalOptions = LayoutOptions.EndAndExpand, Margin = new Thickness(0, 0, 10, 0),
                    IsChecked = habits[i].IsActive,
                };
                checkBoxes[i].CheckedChanged += (sender, e) =>
                {
                    if (sender is CheckBox checkBox)
                    {
                        var index = Array.IndexOf(checkBoxes, checkBox);
                        habits[index].IsActive = !habits[index].IsActive;
                    }
                };
            }
        }

        private void ShowHabits()
        {
            for (var i = 0; i < habits.Length; i++)
            {
                var label = new Label()
                {
                    Text = $"{i + 1}. {habits[i].Line}", TextColor = Color.Black, FontSize = 24,
                    VerticalOptions = LayoutOptions.Center
                };
                grid.RowDefinitions.Add(new RowDefinition() {Height = GridLength.Auto });
                grid.Children.Add(label, 0, i + 1);
                grid.Children.Add(checkBoxes[i], 1, i + 1);
            }
        }

        protected override void OnDisappearing()
        {
            homePage.ShowHabitsList();
        }

        public async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}