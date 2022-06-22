using Saver.ViewModels;
using Saver.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saver.Commands
{
    internal class NavigateToFavoriteCategoriesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private FavoritesViewModel _vm;

        public NavigateToFavoriteCategoriesCommand(FavoritesViewModel viewModel)
        {
            this._vm = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (_vm.FavoriteCategories.Count() > 0) 
            {
                return true;
            }

            return false;
        }

        public async void Execute(object parameter)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FavoriteCategoriesPage());
        }
    }
}
