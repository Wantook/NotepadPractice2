using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Proj.Model;
using Proj.View;

namespace Proj.ViewModel
{
    public class NoteViewModel : INotifyPropertyChanged
    {
        private string _noteTitle;
        private string _noteContent;
        private string _selectedCategory;
        private ObservableCollection<NoteModel> _notes;
        private ObservableCollection<CategoryModel> _categories;

        public NoteViewModel()
        {
            Categories = new ObservableCollection<CategoryModel>
            {
                new CategoryModel { Name = "General" },
                new CategoryModel { Name = "Work" },
                new CategoryModel { Name = "Personal" }
            };

            Notes = new ObservableCollection<NoteModel>();
        }

        public string NoteTitle
        {
            get => _noteTitle;
            set
            {
                _noteTitle = value;
                OnPropertyChanged();
            }
        }

        public string NoteContent
        {
            get => _noteContent;
            set
            {
                _noteContent = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<NoteModel> Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CategoryModel> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public Command AddNoteCommand => new Command(AddNote);

        public Command ShowNotesCommand => new Command(ShowNotes);

        private void AddNote()
        {
            if (!string.IsNullOrEmpty(NoteTitle) && !string.IsNullOrEmpty(NoteContent) && !string.IsNullOrEmpty(SelectedCategory))
            {
                Notes.Add(new NoteModel
                {
                    Title = NoteTitle,
                    Content = NoteContent,
                    Category = SelectedCategory
                });

                NoteTitle = string.Empty;
                NoteContent = string.Empty;
                SelectedCategory = Categories[0].Name; // Reset to default category
            }
        }

        private void ShowNotes()
        {
            // Navigate to NotesPage
            Shell.Current.GoToAsync(nameof(View.NotesPage));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
