using System;
using System.Collections.Generic;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FocusPage : ContentPage
    {
        private PresetState[] presetStates;
        private int currentMinutes = 20;
        private Dictionary<int, string> clockFaceByMinutesCount;
        public FocusPage()
        {
            InitializeComponent();
            InitializePresetStates();
            InitializeClockFaces();
            UpdatePresetButtons();
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

        private void UpdatePresetButtons()
        {
            foreach (var presetState in presetStates)
            {
                if (presetState.IsEmpty)
                    presetState.Button.BackgroundColor = Color.FromHex("#00769CFF");
                else
                {
                    presetState.Button.BackgroundColor = Color.FromHex("#769CFF");
                    presetState.Button.Text = presetState.MinutesCount.ToString();
                }
            }
        }

        private void InitializePresetStates()
        {
            presetStates = new[]
            {
                new PresetState(presetBtn1), new PresetState(presetBtn2), new PresetState(presetBtn3),
                new PresetState(presetBtn4), new PresetState(presetBtn5), new PresetState(presetBtn6),
                new PresetState(presetBtn7)
            };
        }

        private void AddPreset(object sender, EventArgs e)
        {
            ShiftStates();
            presetStates[0].MinutesCount = currentMinutes;
            UpdatePresetButtons();
        }

        private void ShiftStates()
        {
            for (var i = presetStates.Length - 1; i > 0; i--)
                if (!presetStates[i - 1].IsEmpty)
                    presetStates[i].MinutesCount = presetStates[i - 1].MinutesCount;
        }

        private async void OpenTimer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage(TimeSpan.FromMinutes(currentMinutes),
                Color.FromHex("#3D569E"), Color.FromHex("#769CFF")));
        }
    }

    class PresetState
    {
        public Button Button { get; set; }
        public int MinutesCount { get; set; }
        public bool IsEmpty
        {
            get { return MinutesCount == 0; }
        }

        public PresetState(Button button)
        {
            Button = button;
        }
    }
}