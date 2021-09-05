using System;
using System.Windows.Input;
using Fatn.Prototype.ViewModels.Interface;

namespace Fatn.Prototype.ViewModels.Wpf
{
    public class WpfRelayCommand : ICommand, IRaiseCanExecuteChangedEvent
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        public WpfRelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute(parameter);

        public void Execute(object? parameter) => _execute(parameter);

        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}