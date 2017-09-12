using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VCDLeaseHelper.Common
{
    public class CommonData
    {
        public class DelegateCommands : ICommand
        {
            public bool CanExecute(object parameter)
            {
                if (CanExecuteHander == null)
                    return true;
                return CanExecuteHander(parameter);
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                if (ExecuteHander == null)
                    return;
                ExecuteHander(parameter);
            }

            public Func<object, bool> CanExecuteHander;

            public Action<object> ExecuteHander;
        }

        public class NotifyPropertyChanged : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public void RasePropertyChange(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }

}
