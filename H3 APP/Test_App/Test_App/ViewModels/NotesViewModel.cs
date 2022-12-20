using Xamarin.Forms;
using Xamarin.Essentials;
using H3_App.Views;
using H3_App.Data;
using System.Threading.Tasks;
using H3_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace H3_App.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        public List<Note> NotesList = new List<Note>();
        public Command Add { get; }

        private Note _SelectedItem;


        public NotesViewModel()
        {
            Title = "Todo List";
            Add = new Command(OnAddClicked);
        }

        public Note SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        async void OnAddClicked()
        {
            await Shell.Current.GoToAsync(nameof(NoteEntryPage));
        }
    }
}