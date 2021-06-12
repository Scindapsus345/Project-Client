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
    public partial class InitialForm : ContentPage
    {
        private string[] questions = new []
        {
            "Выберите сферу жизни",
            "Дайте название своей проблеме. Написать свой страх, свою установку",
            "Опишите её подробно. Распишите свой страх во всех красках",
            "Вспомните, когда страх впервые появился, триггер, давший начало установке",
            "Перечислите списком множества событий, которые под действием установки, человек сделал и делает за свою жизнь",
            "Ответьте на вопрос: почему и зачем? Во что мы верили тогда, что с тех пор стали действовать так? Подсознание и мы сами хотим для себя добра, так ради какого добра тогда мы это сделали и в это тогда осознанно поверили?",
            "Сформулийте свою ошибочную установку. Как можно точнее",
            "Напишите, какой будет твоя жизнь через 10 лет, если ты продолжишь следовать своей установке",
            "Сформулийте новую установку. Но не с «-1» на «1», а с «-1» на «допускаю, что 1 будет лучше для меня в жизни»",
            "Опишите свою жизнь через 3-5-10-20 лет с новой установкой",
            "Опционально: Выберите вдохновляющую цитату, характеризующую новую установку"
        };
        private string[] answers = new string[11];
        private int i;

        public InitialForm()
        {
            InitializeComponent();
            question.Text = questions[i];
        }

        private void NextBtn_OnClicked(object sender, EventArgs e)
        {
            answers[i] = answer.Text;
            i++;
            if (i == questions.Length - 1)
                nextBtn.Text = "Сохранить";
            else if (i == questions.Length)
                i--;
            answer.Text = "";
            question.Text = questions[i];
        }
    }
}