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
    public partial class PsychologyPage : ContentPage
    {
        public PsychologyPage()
        {
            InitializeComponent();
        }

        public async void OpenTopic(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopicsPage());
        }
    }

    public class ButtonTriggerAction : TriggerAction<VisualElement>
    {
        public Color BackgroundColor { get; set; }

        protected override void Invoke(VisualElement visual)
        {
            var button = visual as Button;
            if (button == null) return;
            if (BackgroundColor != null) button.BackgroundColor = BackgroundColor;
        }
    }
}