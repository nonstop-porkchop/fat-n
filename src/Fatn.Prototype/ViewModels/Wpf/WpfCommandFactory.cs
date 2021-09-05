using System;
using System.Windows.Input;
using Fatn.Prototype.ViewModels.Interface;

namespace Fatn.Prototype.ViewModels.Wpf
{
    public class WpfCommandFactory : ICommandFactory
    {
        public ICommand MakeCommand(Action<object> execute, Func<object,bool> canExecute)
        {
            return new WpfRelayCommand(execute, canExecute);
        }
    }
}