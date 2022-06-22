using Realms;
using Saver.Models;
using Saver.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saver.Commands
{
    internal class AddFavoriteCategoryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly CategoriesViewModel vm;

        public AddFavoriteCategoryCommand(CategoriesViewModel viewModel)
        {
            this.vm = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if(vm != null) 
            {
                return true;
            }

            return false;
        }

        public async void Execute(object parameter)
        {
            Realm _realm = Realm.GetInstance();

            var reqCatId = Environment.SahredData.currentCategory.CategoryId;

            FavoriteCategory[] allFavoriteCategories = _realm.All<FavoriteCategory>().ToArray();
            Category[] allCategories = _realm.All<Category>().ToArray();
            FavoriteCategory requiredCategory  = null;

            List<FavoriteCategory> filteredFavorites = allFavoriteCategories.Where(c => c.CategoryId.Equals(reqCatId)).ToList();

            if (filteredFavorites.Count() == 0) 
            {
                requiredCategory = null;
            }
            if (filteredFavorites.Count() > 1) 
            {
                requiredCategory = filteredFavorites[0];

                for (int i = 1; i < filteredFavorites.Count; i++) 
                {
                    _realm.Write(() => _realm.Remove(filteredFavorites[i]));
                }

                filteredFavorites.RemoveRange(1, filteredFavorites.Count - 1);
            }

            if (requiredCategory == null)
            {
                requiredCategory = new FavoriteCategory() { IsFavorite = false, CategoryId = reqCatId };
                _realm.Write(() => _realm.Add(requiredCategory));
                
                var relatedCategory = allCategories.Single(c => c.CategoryId.Equals(reqCatId));
            }
            if (requiredCategory.IsFavorite == false)
            {
                _realm.Write(() => requiredCategory.IsFavorite = true);
                
                var relatedCategory = allCategories.Single(c => c.CategoryId.Equals(reqCatId));

                await Application.Current.MainPage.DisplayAlert("Done", $"Favorite Category Added: {relatedCategory.Name}", "Ok");
                return;
            }
            if (requiredCategory.IsFavorite == true)
            {
                _realm.Write(() => requiredCategory.IsFavorite = false);

                var relatedCategory = allCategories.Single(c => c.CategoryId.Equals(reqCatId));

                await Application.Current.MainPage.DisplayAlert("Done", $"Category: {relatedCategory.Name} Was Unset As Favorite", "Ok");
                return;
            }
        }
    }
}
