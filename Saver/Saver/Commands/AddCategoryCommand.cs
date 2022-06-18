using Realms;
using Saver.Models;
using Saver.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saver.Commands
{
    public class AddCategoryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Realm realmInstance;

        private SettingsViewModel viewModel;

        public AddCategoryCommand(SettingsViewModel vm)
        {
            this.viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            Realm _realm = Realm.GetInstance();

            if (_realm != null)
            {
                this.realmInstance = _realm;
                return true;
            }
            return false;
        }

        public async void Execute(object parameter)
        {
            Category category = new Category()
            {
                CategoryId = Guid.NewGuid(),
                Name = (string)parameter
            };

            realmInstance.Write(() => realmInstance.Add(category));

            viewModel.NewCategoryName = "";

            await Application.Current.MainPage.DisplayAlert("Done", $"Category Added: {category.Name}", "Ok");
        }
    }
}
