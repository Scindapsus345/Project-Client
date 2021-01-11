using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaditationPage : ContentPage
    {
        private int currentMinutes = 20;
        private Dictionary<int, string> clockFaceByMinutesCount;
        public MaditationPage()
        {
            InitializeComponent();
            InitializeClockFaces();
            UpdateClockFace();
        }

        private void UpdateClockFace()
        {
            clockFace.Source = clockFaceByMinutesCount[currentMinutes];
        }

        private void SetClockFace(object sender, EventArgs e)
        {
            if (sender is Button button && int.TryParse(button.Text, out var minutes))
            {
                currentMinutes = minutes;
                UpdateClockFace();
            }
        }

        private void InitializeClockFaces()
        {
            clockFaceByMinutesCount = new Dictionary<int, string>();
            for (var i = 5; i <= 60; i += 5)
                clockFaceByMinutesCount[i] = $"min{i}";
        }

        private async void OpenTutorial(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MeditationTutorialPage());
        }
    }
}