using System;
using System.Collections.Generic;
using SwiftCode.ViewModels;
using Xamarin.Forms;

namespace SwiftCode.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            (BindingContext as MainViewModel).GetNewQuoteCommand.ExecuteAsync();
        }
    }
}
