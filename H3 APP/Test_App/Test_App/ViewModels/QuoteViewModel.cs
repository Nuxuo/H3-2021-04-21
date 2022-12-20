using Xamarin.Forms;
using System.Collections.ObjectModel;
using H3_App.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace H3_App.ViewModels
{
    public class QuoteViewModel : BaseViewModel
    {
        public ObservableCollection<Quote> TodoCollection { get; set; } = new ObservableCollection<Quote>();
        public Command NewQuoteCommand { get; }
        public Command<object> DeleteCommand { get; }

        public QuoteViewModel()
        {
            Title = "Kanye Quotes";
            NewQuoteCommand = new Command(NewQuote);
            DeleteCommand = new Command<object>(NewDelete);
        }

        private void NewQuote()
        {
            Quote NewQuote = new Quote();
            NewQuote.Agenda = getQouteMethod();
            TodoCollection.Add(NewQuote);
        }

        private string getQouteMethod()
        {
            var url = "https://api.kanye.rest";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var json = reader.ReadToEnd();
            string data = JObject.Parse(json)["quote"].ToString();

            return data;
        }

        private void NewDelete(object sender)
        {
            var contact = sender as Quote;
            TodoCollection.Remove(contact);
        }
    }
}