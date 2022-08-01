using Realms;
using Saver.Models;
using Saver.Services;
using Saver.Services.Contracts;
using Saver.Services.ServiceExtensions;
using Saver.ViewModels;
using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Saver.Commands
{
    public class SyncAllContentCommand : ICommand
    {
        private Realm realmInstance;

        public event EventHandler CanExecuteChanged;
        private SettingsViewModel vm;

        public SyncAllContentCommand(SettingsViewModel viewModel)
        {
            this.vm = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            Realm _realm = Realm.GetInstance();

            if (_realm != null)
            {
                this.realmInstance = _realm;
                return true;
            }
            return false;
        }

        public async void Execute(object parameter)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // некоторые действия 
            }

            var allCategories = this.realmInstance.All<Category>();
            var allPublications = this.realmInstance.All<Content>();

            var payloadData = new ContentRepresentationData();

            foreach (var category in allCategories) 
            {
                payloadData.Content = allPublications.ToArray();
                payloadData.Categories = allCategories.ToArray();
            }

            if (this.vm.HostIpAddress == "" | this.vm.HostIpAddress == String.Empty) 
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Please soecify IP address of host", "Ok");
                return;
            }

            var backendClient = BackendServiceClient.GetInstance(this.vm.HostIpAddress);

            var result = await backendClient.SyncAllContent(payloadData);

            if (result == System.Net.HttpStatusCode.OK)
            {
                await Application.Current.MainPage.DisplayAlert("Done", $"Content Syncronized", "Ok");
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert("Error!", $"Something went wrong: {result}", "Ok");
            }
        }
    }
}
