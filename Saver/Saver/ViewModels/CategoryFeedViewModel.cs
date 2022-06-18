using Realms;
using Saver.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Saver.ViewModels
{
    public class CategoryFeedViewModel: BaseViewModel
    {
        private ObservableCollection<Content> contentCollection;
        public ObservableCollection<Content> ContentCollection { get => contentCollection; set => contentCollection = value; }

        public CategoryFeedViewModel()
        {
            this.ContentCollection = new ObservableCollection<Content>();

            Realm _realm = Realm.GetInstance();
            Content[] allRelatedContent = _realm.All<Content>().ToArray();

            foreach (var cat in allRelatedContent.Where(c => c.CategoryId.Value == Environment.SahredData.currentCategory.CategoryId).ToArray())
            {
                ContentCollection.Add(cat);
            }
        }
    }
}
