using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ICommandWpf
{
    public class MainWindowViewModel
    {
        public ICommand MyCommand { get; set;  }

        public ICommand MyRelayCommand { get; set; }

        public ICommand MyActionCommand { get; set; }

        public DelegateCommand  MyDelegate { get; set; }

        public MainWindowViewModel()
        {
            MyCommand = new Command();

            MyRelayCommand = new RelayCommand((o) => { return true; }, (o) => { MessageBox.Show("Relay1"); } );

            MyActionCommand = new ActionCommand<string>((s) => { return true; },
                (s) => { MessageBox.Show(s); });

            MyDelegate = new DelegateCommand(ExecuteCommand, CanExecuteMethod);

            Task.Run(() =>
            {
                while (true)
                {
                    MyDelegate.RaiseCanExecuteChanged(); // go check the enable/disable
                    Thread.Sleep(500);
                }

            });
        }

        // =========================== delegate
        private bool CanExecuteMethod()
        {
            return DateTime.Now.Second % 2 == 0;
        }

        private void ExecuteCommand()
        {
            MessageBox.Show("Delegate no code behind!");
        }
    }
}
