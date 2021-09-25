using System.Collections.ObjectModel;

namespace Fatn.Avalonia.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<ViewModelBase> TabItems { get; set; } = new()
        {
            new InboxViewModel()
        };
    }
}