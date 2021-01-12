using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        private bool pause;
        private Stopwatch stopWatch;
        private TimeSpan timeSpan;
        public TimerPage(TimeSpan timeSpan, Color mainColor, Color subColor)
        {
            InitializeComponent();
            stopWatch = new Stopwatch();
            this.timeSpan = timeSpan;
            StartTimer();
            SetColors(mainColor, subColor);
            var seconds = timeSpan.Seconds < 10 ? $"0{timeSpan.Seconds}" : timeSpan.Seconds.ToString();
            var minutes = timeSpan.Minutes < 10 ? $"0{timeSpan.Minutes}" : timeSpan.Minutes.ToString();
            time.Text = $"{minutes}:{seconds}";
        }

        private void SetColors(Color mainColor, Color subColor)
        {
            BackgroundColor = subColor;
            time.TextColor = mainColor;
            pauseBtn.BackgroundColor = mainColor;
            finishBtn.BackgroundColor = mainColor;
        }

        private void StartTimer()
        {
            timeSpan = timeSpan.Add(TimeSpan.FromMilliseconds(500));
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (!pause)
                {
                    var newTimeSpan = timeSpan.Subtract(TimeSpan.FromMilliseconds(stopWatch.ElapsedMilliseconds));
                    var seconds = newTimeSpan.Seconds < 10 ? $"0{newTimeSpan.Seconds}" : newTimeSpan.Seconds.ToString();
                    var minutes = newTimeSpan.Minutes < 10 ? $"0{newTimeSpan.Minutes}" : newTimeSpan.Minutes.ToString();
                    time.Text = $"{minutes}:{seconds}";
                    if (newTimeSpan.TotalSeconds <= 0)
                    {
                        Navigation.PopAsync();
                        return false;
                    }
                }
                return true;
            });
            stopWatch.Start();
        }

        public void Pause(object sender, EventArgs e)
        {
            if (pause)
            {
                stopWatch.Start();
                pauseBtn.Text = "Пауза";
            }
            else
            {
                stopWatch.Stop();
                pauseBtn.Text = "Продолжить";
            }
            pause = !pause;
        }

        public void Finish(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}