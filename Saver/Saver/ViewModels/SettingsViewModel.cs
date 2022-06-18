using Realms;
using Saver.Commands;
using Saver.Models;
using System.Collections.ObjectModel;

namespace Saver.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }

        private string newCategoryName;

        public string NewCategoryName
        {
            get => newCategoryName;
            set { this.newCategoryName = value; OnPropertyChanged("NewCategoryName"); }
        }

        private Category selectedCategory;

        public Category SelectedCategory 
        { 
            get => selectedCategory;
            set { this.selectedCategory = value; OnPropertyChanged("SelectedCategory"); }
        }

        private string contentTitle;

        public string ContentTitle 
        { 
            get => contentTitle;
            set { contentTitle = value; OnPropertyChanged("ContentTitle"); } }

        private string contentUri;

        public string ContentUri 
        { 
            get => contentUri;
            set { contentUri = value; OnPropertyChanged("ContentUri"); }
        }


        private AddCategoryCommand addCategoryCommand;
        public AddCategoryCommand AddCategoryCommand
        {
            get
            {
                return addCategoryCommand ??
                    (addCategoryCommand = new AddCategoryCommand(this));
            }
        }

        private AddContentCommand addContentCommand;

        public AddContentCommand AddContentCommand
        {
            get
            {
                return this.addContentCommand ?? (addContentCommand = new AddContentCommand(this, obj =>
                {

                    Content content = new Content()
                    {
                        CategoryId = SelectedCategory.CategoryId,
                        ImageUri = ContentUri,
                        Title = ContentTitle
                    };

                    Realm _realm = Realm.GetInstance();

                    _realm.Write(() => _realm.Add<Content>(content));
                }));
            }
        }


        public SettingsViewModel()
        {
            this.Categories = new ObservableCollection<Category>();

            Realm _realm = Realm.GetInstance();

            var allCategories = _realm.All<Category>();

            foreach(var cat in allCategories) 
            {
                Categories.Add(cat);
            }
        }
    }
}
