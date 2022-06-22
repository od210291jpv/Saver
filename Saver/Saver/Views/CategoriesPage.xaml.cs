using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saver.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();

            this.Appearing += OnPageAppearing;
        }

        private async void OnPageAppearing(object sender, EventArgs e)
        {            
        }
    }
}