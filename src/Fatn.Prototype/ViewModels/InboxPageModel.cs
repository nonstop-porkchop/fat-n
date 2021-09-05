using System;
using System.ComponentModel;
using System.Windows.Input;
using Fatn.Api;
using Fatn.Prototype.ViewModels.Interface;

namespace Fatn.Prototype.ViewModels
{
    public class InboxPageModel : PageModel, ISupportInitialize
    {
        private FatnClient _client;
        private ICommandFactory _commandFactory;
        private ICommand _sendGreetCommand;
        private string _greetName;
        private string _greetingResponse;

        public FatnClient Client
        {
            get => _client;
            set
            {
                if (Equals(value, _client)) return;
                _client = value;
                OnPropertyChanged();
            }
        }

        public ICommandFactory CommandFactory
        {
            get => _commandFactory;
            set
            {
                if (Equals(value, _commandFactory)) return;
                _commandFactory = value;
                OnPropertyChanged();
            }
        }

        public void BeginInit()
        {
        }

        public void EndInit()
        {
            if (CommandFactory is null) throw new ArgumentNullException(nameof(CommandFactory));
            SendGreetCommand = CommandFactory.MakeCommand(ExecuteSendGreet, CanExecuteSendGreet);
        }

        private bool CanExecuteSendGreet(object arg)
        {
            return Client != null && !string.IsNullOrWhiteSpace(GreetName);
        }

        private async void ExecuteSendGreet(object obj)
        {
            GreetingResponse = await Client.Greet(GreetName);
            GreetName = null;
        }

        public ICommand SendGreetCommand
        {
            get => _sendGreetCommand;
            set
            {
                if (Equals(value, _sendGreetCommand)) return;
                _sendGreetCommand = value;
                OnPropertyChanged();
            }
        }

        public string GreetName
        {
            get => _greetName;
            set
            {
                if (value == _greetName) return;
                _greetName = value;
                OnPropertyChanged();
            }
        }

        public string GreetingResponse
        {
            get => _greetingResponse;
            set
            {
                if (value == _greetingResponse) return;
                _greetingResponse = value;
                OnPropertyChanged();
            }
        }
    }
}