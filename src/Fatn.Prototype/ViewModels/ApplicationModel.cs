using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Fatn.Prototype.ViewModels
{
    public sealed class ApplicationModel : INotifyPropertyChanged
    {
        private ObservableCollection<PageModel> _pages = new();
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<PageModel> Pages
        {
            get => _pages;
            set
            {
                if (Equals(value, _pages)) return;
                _pages = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}