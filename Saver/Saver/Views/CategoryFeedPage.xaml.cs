using Saver.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saver.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryFeedPage : ContentPage
    {

        private Category currentCat;

        public Category CurrentCat { get => currentCat; set => currentCat = value; }


        public CategoryFeedPage(Category category)
        {
            InitializeComponent();
        }

    }
}