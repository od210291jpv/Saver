using Realms;
using Saver.Commands;
using Saver.Models;
using Saver.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saver.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }

        private Category selectedCategory;

        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public ICommand NavigateToFeedItemCommand
        {
            get;
        }

        public CategoriesViewModel()
        {
            this.NavigateToFeedItemCommand = new NavigateToPageCommand(this);

            this.Categories = new ObservableCollection<Category>();

            Realm _realm = Realm.GetInstance();
            var allCategories = _realm.All<Category>();

            foreach (var cat in allCategories)
            {
                Categories.Add(cat);
            }
        }
    }
}
