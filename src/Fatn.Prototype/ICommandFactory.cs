using System;
using System.Windows.Input;

namespace Fatn.Prototype
{
    public interface ICommandFactory
    {
        ICommand MakeCommand(Action<object> execute, Func<object,bool> canExecute);
    }
}