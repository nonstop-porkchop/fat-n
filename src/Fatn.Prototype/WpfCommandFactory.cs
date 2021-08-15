using System;
using System.Windows.Input;

namespace Fatn.Prototype
{
    public class WpfCommandFactory : ICommandFactory
    {
        public ICommand MakeCommand(Action<object> execute, Func<object,bool> canExecute)
        {
            return new WpfRelayCommand(execute, canExecute);
        }
    }
}