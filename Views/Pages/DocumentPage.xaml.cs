using Catalogue.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Catalogue.Views.Pages
{
    public partial class DocumentPage : INavigableView<DocumentViewModel>
    {
        public DocumentViewModel ViewModel { get; }

        public DocumentPage(DocumentViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
