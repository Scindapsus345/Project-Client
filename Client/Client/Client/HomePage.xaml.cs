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
    public partial class HomePage : ContentPage
    {
        private Habit[] habits;
        public HomePage()
        {
            InitializeComponent();
            InitializeHabits();
            ShowHabitsList();
        }

        public void ShowHabitsList()
        {
            habitsList.Children.Clear();
            var activeHabits = habits.Where(habit => habit.IsActive).ToList();
            if (activeHabits.Count == 0)
            {
                habitsList.Children.Add(new Label()
                {
                    Text = $"Вы еще не добавили ни одной полезной привычки :(",
                    TextColor = Color.Black,
                    FontSize = 20,
                    Padding = new Thickness(3),
                    Margin = new Thickness(10, 0, 10, 0),
                });
                return;
            }
            for (var i = 0; i < activeHabits.Count; i++)
            {
                var label = new Label()
                {
                    Text = $"{i + 1}. {activeHabits[i].Line}",
                    TextColor = Color.Black,
                    FontSize = 24,
                    Padding = new Thickness(3),
                    Margin = new Thickness(10,0,10,0),
                    BackgroundColor = Color.FromHex("#C3FFD1")
                };
                var changeColorTap = new TapGestureRecognizer();
                changeColorTap.Tapped += (s, e) =>
                {
                    if (s is Label habit)
                    {
                        if (habit.BackgroundColor == Color.FromHex("#C3FFD1"))
                            habit.BackgroundColor = Color.FromHex("#00CC2D");
                        else
                            habit.BackgroundColor = Color.FromHex("#C3FFD1");
                    }
                };
                label.GestureRecognizers.Add(changeColorTap);
                habitsList.Children.Add(label);
            }
        }

        private void InitializeHabits()
        {
            habits = new Habit[13];
            habits[0] = new Habit("Выпить стакан воды утром", true);
            habits[1] = new Habit("Пройти 10 000 шагов", true);
            habits[2] = new Habit("Спать на правом боку", true);
            habits[3] = new Habit("Покрутить обруч 30 минут", false);
            habits[4] = new Habit("Прочитать 20 страниц книги", false); 
            habits[5] = new Habit("Побыть на свежем воздухе 2 часа в день", false); 
            habits[6] = new Habit("Пользоваться телефоном меньше часа в день", false);
            habits[7] = new Habit("Сделать домашку", false);
            habits[8] = new Habit("Не пить кофе день", false);
            habits[9] = new Habit("Не съесть больше 2000ккал", false);
            habits[10] = new Habit("Найти себе девушку", false);
            habits[11] = new Habit("Сходить в спортзал", false);
            habits[12] = new Habit("Найти себе девушку", false);
        }

        public async void AddHabits(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHabitsPage(habits, this));
        }
    }
}