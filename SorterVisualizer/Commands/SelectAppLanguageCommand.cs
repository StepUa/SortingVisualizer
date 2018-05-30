using System;
using System.Windows.Input;

namespace SorterVisualizer.Commands
{
    class SelectAppLanguageCommand : ICommand
    {
        private Action<object> _action;
        private Predicate<object> _predicate;

        public SelectAppLanguageCommand(Action<object> action, Predicate<object> predicate)
        {
            _action = action;
            _predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _predicate == null ? false : _predicate.Invoke(parameter);
        }
        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action.Invoke(parameter);
            }
        }
    }
}
