using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfTreeView
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action mAction;

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => mAction?.Invoke();
    }
}
