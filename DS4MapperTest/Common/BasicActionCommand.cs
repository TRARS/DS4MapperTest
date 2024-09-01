using System;
using System.Windows.Input;

namespace DS4MapperTest.Common
{
    public class BasicActionCommand : ICommand
    {
        private Action<object> executeAction;

        public event EventHandler CanExecuteChanged;

        public BasicActionCommand(Action<object> tempAct)
        {
            executeAction = tempAct;
        }

        public bool CanExecute(object _)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeAction?.Invoke(parameter);
        }
    }
}
