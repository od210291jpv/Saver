using Realms;
using Saver.Commands;
using Saver.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Saver.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        public ObservableCollection<FavoriteCategory> FavoriteCategories { get; set; }

        public ObservableCollection<Category> Categories { get; set; }

        public ObservableCollection<Content> FavoriteContent { get; set; }

        private Category selectedFavoriteCategory;

        public Category SelectedFavoriteCategory
        {
            get { return selectedFavoriteCategory; }
            set
            {
                selectedFavoriteCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public ICommand NavigateToFeedItemCommand
        {
            get;
        }

        public ICommand NavigateToFavoriteCategoriesCommand 
        { 
            get;
        }

        public FavoritesViewModel()
        {
            this.NavigateToFeedItemCommand = new NavigateToFavoriteCategoriesPageCommand(this);
            this.NavigateToFavoriteCategoriesCommand = new NavigateToFavoriteCategoriesCommand(this);
            this.FavoriteCategories = new ObservableCollection<FavoriteCategory>();
            this.Categories = new ObservableCollection<Category>();
            this.FavoriteContent = new ObservableCollection<Content>();

            Realm _realm = Realm.GetInstance();
            var allFavCategories = _realm.All<FavoriteCategory>().ToArray();
            var allCategories = _realm.All<Category>().ToArray();

            foreach (var fc in allFavCategories) 
            {
                FavoriteCategories.Add(fc);
            }

            var filteredCategories = allCategories.Where(c =>
            this.FavoriteCategories.Where(fc =>
            fc.IsFavorite == true).Select(fc =>
            fc.CategoryId).ToArray().Contains(c.CategoryId) == true).ToArray();

            foreach (var c in filteredCategories) 
            {
                this.Categories.Add(c);
            }
        }
    }
}
