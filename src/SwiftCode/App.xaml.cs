using System;
using SwiftCode.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwiftCode
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Sharpnado.MaterialFrame.Initializer.Initialize(false, false);

            MainPage = new MainView();
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
