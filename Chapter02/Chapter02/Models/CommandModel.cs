using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Chapter02.Models
{
    public class CommandModel : ICommand
    {
        private Func<Boolean> canExecute;
        private Action execute;

        public CommandModel(Action action) : this(action, null)
        {

        }

        public CommandModel(Action action, Func<Boolean> canAction)
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
