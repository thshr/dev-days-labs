using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using DevDaysSpeakers.Model;
using JetBrains.Annotations;
using Plugin.TextToSpeech;
using Xamarin.Forms;

namespace DevDaysSpeakers.ViewModel
{
    class SingleSpeakerViewModel : INotifyPropertyChanged
    {
        public Command SpeakCommand { get; }

        public Command GoToWebCommand { get; }

        public SingleSpeakerViewModel(Speaker speaker)
        {
            Speaker = speaker;

            SpeakCommand = new Command(Speak);
            GoToWebCommand = new Command(GoToWeb);
        }

        public Speaker Speaker { get; }

        private void GoToWeb()
        {
            Device.OpenUri(new Uri(Speaker.Website));
        }

        private void Speak()
        {
            CrossTextToSpeech.Current.Speak(Speaker.Description);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
