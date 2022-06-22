using Saver.ViewModels;
using Saver.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saver.Commands
{
    internal class NavigateToFavoriteCategoriesPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private FavoritesViewModel _vm;

        public NavigateToFavoriteCategoriesPageCommand(FavoritesViewModel vm)
        {
            this._vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Environment.SahredData.currentCategory = this._vm.SelectedFavoriteCategory;
            await Application.Current.MainPage.Navigation.PushAsync(new CategoryFeedPage(this._vm.SelectedFavoriteCategory));
        }
    }
}
