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
    public partial class QuestionsPage : ContentPage
    {
        private int i = 1;

        private List<string> words = new List<string>()
        {
            "усталость",
            "страх",
            "тревога",
            "депрессия",
            "апатия",
            "отношения",
            "обреченность"
        };

        public QuestionsPage()
        {
            InitializeComponent();
        }

        public void NextQuestion(object sender, EventArgs e)
        {
            if (i != words.Count)
            {
                question.Text = $"У вас присутствует {words[i]}?";
                if (i == 5)
                    question.Text = $"Вас беспокоят проблемы в отношениях?";
                if (i == 6)
                    question.Text = $"Вы чувствуете себя обреченным?";
                i++;
            }
            else
                ToMainPage();
        }

        public void Skip(object sender, EventArgs e)
        {
            ToMainPage();
        }

        private async void ToMainPage()
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }
    }
}