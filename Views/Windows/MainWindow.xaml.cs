using Catalogue.Models;
using Catalogue.ViewModels.Windows;
using Catalogue.Views.Pages;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace Catalogue.Views.Windows
{
    public partial class MainWindow
    {
        private Type[] _skipPages = { typeof(DashboardPage) };

        public MainWindowViewModel ViewModel { get; }

        public MainWindow(
            MainWindowViewModel viewModel,
            INavigationService navigationService,
            IServiceProvider serviceProvider,
            IContentDialogService contentDialogService
        )
        {
            Wpf.Ui.Appearance.Watcher.Watch(this);

            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();

            navigationService.SetNavigationControl(NavigationView);
            contentDialogService.SetContentPresenter(RootContentDialog);

            NavigationView.SetServiceProvider(serviceProvider);
        }

        private void NavigationView_Navigated(NavigationView sender, NavigatedEventArgs args)
        {
            BreadcrumbBar.Visibility = _skipPages.Any(s => s.ToString().Equals(args.Page.ToString())) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void NavigationView_SelectionChanged(NavigationView sender, RoutedEventArgs args)
        {
            if (sender.SelectedItem is NavigationViewItem item && item.TargetPageType!.Equals(typeof(DocumentPage)))
                WeakReferenceMessenger.Default.Send(new SendFileMessage(sender.SelectedItem?.TargetPageTag!));
        }
    }
}
