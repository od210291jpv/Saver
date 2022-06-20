using Realms;
using System;
using System.Windows.Input;
using Xamarin.Essentials;

namespace Saver.Commands
{
    public class BackupDbCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var result = await FilePicker.PickAsync();
        }
    }
}
