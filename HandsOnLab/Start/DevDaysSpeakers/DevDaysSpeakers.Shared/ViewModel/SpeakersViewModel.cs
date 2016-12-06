using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using DevDaysSpeakers.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace DevDaysSpeakers.ViewModel
{
    public class SpeakersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Speaker> Speakers { get; set; } // = new ObservableCollection<Speaker>();

        public Speaker SelSpeaker
        {
            get { return _selSpeaker; }
            set
            {
                if (Equals(value, _selSpeaker)) return;
                _selSpeaker = value;
                OnPropertyChanged();
                MessagingCenter.Send(this, "", new );
            }
        }

        public Command GetSpeakersCommand { get; set; }

        public SpeakersViewModel()
        {
            GetSpeakersCommand = new Command(async () => await GetSpeaker(), () => !IsBusy);
            Speakers = new ObservableCollection<Speaker>();
        }

        private bool _busy;
        private Speaker _selSpeaker;

        public bool IsBusy
        {
            get { return _busy; }
            set
            {
                if (value == _busy) return;
                _busy = value;
                OnPropertyChanged();
                GetSpeakersCommand.ChangeCanExecute();
            }
        }


        private async Task GetSpeaker()
        {
            if (IsBusy) return;

            Exception error = null;

            try
            {
                IsBusy = true;
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync("http://demo4404797.mockable.io/speakers");
                    var items = JsonConvert.DeserializeObject<List<Speaker>>(json);

                    //Speakers = new ObservableCollection<Speaker>(items);
                    Speakers.Clear();
                    foreach (var item in items)
                        Speakers.Add(item);
                }
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");

        }






        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
