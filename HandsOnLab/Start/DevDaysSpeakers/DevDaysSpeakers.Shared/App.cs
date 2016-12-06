using DevDaysSpeakers.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevDaysSpeakers.ViewModel;
using Xamarin.Forms;

namespace DevDaysSpeakers
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var content = new SpeakersPage { BindingContext = new SpeakersViewModel() };

            MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
