using System;
using System.Diagnostics;
using System.Windows.Input;

namespace MvvmBase
{
    public class CommandBase : ICommand
    {
        private Func<Boolean> canExecute;
        private Action execute;

        public CommandBase(Action action)
            : this(action, null)
        {

        }
        public CommandBase(Action action, Func<Boolean> canAction)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            execute = action;
            canExecute = canAction;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
