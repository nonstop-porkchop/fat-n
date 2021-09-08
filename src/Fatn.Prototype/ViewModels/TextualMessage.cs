namespace Fatn.Prototype.ViewModels
{
    public class TextualMessage : ConversationMessage
    {
        private string _messageText;

        public string MessageText
        {
            get => _messageText;
            set
            {
                if (value == _messageText) return;
                _messageText = value;
                OnPropertyChanged();
            }
        }

        public bool FromCurrentUser { get; set; }
    }
}