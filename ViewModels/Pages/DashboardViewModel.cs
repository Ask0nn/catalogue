using Catalogue.Models;
using CommunityToolkit.Mvvm.Messaging;
using Wpf.Ui.Controls;

namespace Catalogue.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject, INavigationAware, IRecipient<SendFileMessage>
    {
        private bool _isInitialized = false;
        private INavigationService _navigationService;

        public DashboardViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            WeakReferenceMessenger.Default.Register(this);
        }

        public void OnNavigatedTo()
        {            
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom()
        {
        }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }

        public void Receive(SendFileMessage message) =>
            System.Windows.MessageBox.Show(message.Value);

        [RelayCommand]
        private void OnUriNavigate(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                return;

            System.Diagnostics.ProcessStartInfo sInfo = new(new Uri(uri).AbsoluteUri)
            {
                UseShellExecute = true
            };

            System.Diagnostics.Process.Start(sInfo);
        }
    }
}
