using Xamarin.Forms;
using Xamarin.Essentials;
using H3_App.Models;
using System;

namespace H3_App.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]

    public class NoteEntryViewModel : BaseViewModel
    {
        public string ItemId{ set { LoadNote(value); } }
        private Note _CurrentNote;

        public Command Save { get; }
        public Command Cancel { get; }

        public NoteEntryViewModel()
        {
            Title = "New Note";
            _CurrentNote = new Note();
            Save = new Command(OnSaveButtonClicked);
            Cancel = new Command(OnDeleteButtonClicked);
        }

        public Note CurrentNote
        {
            get => _CurrentNote;
            set => SetProperty(ref _CurrentNote, value);
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                Note note = await App.Database.GetNoteAsync(id);
                CurrentNote = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        private async void OnSaveButtonClicked()
        {
            var note = (Note)CurrentNote;
            note.Date = DateTime.UtcNow;
            note.Checked = false;

            await App.Database.SaveNoteAsync(note);
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButtonClicked()
        {
            var note = (Note)CurrentNote;

            await App.Database.DeleteNoteAsync(note);
            await Shell.Current.GoToAsync("..");
        }
    }
}