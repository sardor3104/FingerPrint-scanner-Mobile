﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fingerprint
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
                MainPage = new NavigationPage(new LoginUI());
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
