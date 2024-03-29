﻿using Saver.Models;
using Saver.ViewModels;
using Saver.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saver.Commands
{
    public class NavigateToPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private CategoriesViewModel _vm;

        public NavigateToPageCommand(CategoriesViewModel vm)
        {
            this._vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Environment.SahredData.currentCategory = this._vm.SelectedCategory;
            await Application.Current.MainPage.Navigation.PushAsync(new CategoryFeedPage(this._vm.SelectedCategory));
        }
    }
}
