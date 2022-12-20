using System;
using System.Linq;
using H3_App.Models;
using H3_App.ViewModels;
using Xamarin.Forms;

namespace H3_App.Views
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }
        async void OnSelectionChanged(object sender ,SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)}?{nameof(NoteEntryViewModel.ItemId)}={note.ID.ToString()}");
            }
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }
    }
}