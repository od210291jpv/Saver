using Realms;
using Saver.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Saver.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        private ObservableCollection<Content> contentCollection;
        public ObservableCollection<Content> ContentCollection { get => contentCollection; set => contentCollection = value; }

        public FeedViewModel()
        {
            this.ContentCollection = new ObservableCollection<Content>();

            Realm _realm = Realm.GetInstance();
            Content[] allRelatedContent = _realm.All<Content>().ToArray();

            foreach (var cat in allRelatedContent.ToArray())
            {
                ContentCollection.Add(cat);
            }
        }
    }
}
