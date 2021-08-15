using System.Collections.ObjectModel;

namespace Fatn.Prototype.ViewModels
{
    public class FeedPageModel : PageModel
    {
        private ObservableCollection<Post> _posts = new ();

        public ObservableCollection<Post> Posts
        {
            get => _posts;
            set
            {
                if (Equals(value, _posts)) return;
                _posts = value;
                OnPropertyChanged();
            }
        }
    }
}