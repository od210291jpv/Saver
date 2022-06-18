using Realms;
using Saver.Models;
using Saver.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saver.Commands
{
    public class AddContentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> execute;
        private SettingsViewModel viewModel;

        public AddContentCommand(SettingsViewModel vm, Action<object> _execute)
        {
            this.execute = _execute;
            this.viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            Realm _realm = Realm.GetInstance();

            if (_realm != null)
            {
                return true;
            }
            return false;
        }

        public async void Execute(object parameter)
        {
            this.execute(parameter);
            await Application.Current.MainPage.DisplayAlert("Done", $"New Content Added!", "Ok");
            this.viewModel.ContentUri = "";
        }
    }
}
