using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using DevDaysSpeakers.Model;
using DevDaysSpeakers.ViewModel;


namespace DevDaysSpeakers.View
{
    public partial class SpeakersPage : ContentPage
    {
        //SpeakersViewModel vm;
        public SpeakersPage()
        {
            InitializeComponent();

            //Create the view model and set as binding context
            //vm = new SpeakersViewModel();
            //BindingContext = vm;
            
            MessagingCenter.Subscribe<Speaker>(this,"Navigation", OnMsgNavReceived);
        }

        private void OnMsgNavReceived(Speaker speaker)
        {
            var detailsPage = new DetailsPage (speaker);
            Navigation.PushAsync(detailsPage);
        }
    }
}
