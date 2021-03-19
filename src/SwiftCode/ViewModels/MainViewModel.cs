using System;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using SwiftCode.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwiftCode.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string quote;
        public string Quote
        {
            get { return quote; }
            set
            {
                quote = value;
                OnPropertyChanged();
            }
        }

        public AsyncCommand GetNewQuoteCommand { get; }
        public AsyncCommand ClipboardCommand { get; }

        public MainViewModel()
        {
            GetNewQuoteCommand = new AsyncCommand(ExecuteGetQuoteCommand);
            ClipboardCommand = new AsyncCommand(ExecuteClipboardCommand);
        }

        private async Task ExecuteClipboardCommand()
        {
            if (String.IsNullOrEmpty(Quote))
                return;

            await Clipboard.SetTextAsync(Quote);

            ToastConfig.DefaultBackgroundColor = Color.FromHex("#c39977");
            ToastConfig.DefaultMessageTextColor = Color.White;

            UserDialogs.Instance.Toast("Now in your clipboard");
        }

        private async Task ExecuteGetQuoteCommand()
        {
            IsBusy = true;

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://api.taylor.rest/");
            if (String.IsNullOrEmpty(response))
                return;

            var quote = JsonConvert.DeserializeObject<Quote>(response);
            Quote = quote.Message;

            IsBusy = false;
        }
    }
}