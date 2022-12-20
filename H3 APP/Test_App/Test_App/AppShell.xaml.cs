using System;
using System.Collections.Generic;
using H3_App.Views;
using H3_App.ViewModels;
using Xamarin.Forms;

namespace H3_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
        }
    }
}
