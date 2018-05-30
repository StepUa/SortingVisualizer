using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SorterVisualizer.ViewModels;

namespace SorterVisualizer.Commands
{
    class VerifyCollectionCommand : ICommand
    {
        Action<object> _action;
        Predicate<object> _predicate;

        public VerifyCollectionCommand(Action<object> action, Predicate<object> predicate)
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
