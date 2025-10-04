using LibraryManagementApp.ICommand;
using LibraryManagementApp.ViewModels;
using LibraryManagementApp.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace LibraryManagementApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private UserControl? _currentView;
        public UserControl? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        private string _pageHeader = "Dashboard";
        public string PageHeader
        {
            get => _pageHeader;
            set { _pageHeader = value; OnPropertyChanged(); }
        }

        // Commands
        public System.Windows.Input.ICommand ShowDashboardCommand { get; }

        public MainWindowViewModel()
        {
            // Initialize commands
            ShowDashboardCommand = new RelayCommand(param => Navigate(param?.ToString()));
            //ShowBooksCommand = new RelayCommand(o => CurrentView = new Views.BooksView());
            //ShowBorrowRecordsCommand = new RelayCommand(o => CurrentView = new Views.BorrowRecordsView());
            //ShowMembersCommand = new RelayCommand(o => CurrentView = new Views.MembersView());
            //ShowSettingsCommand = new RelayCommand(o => CurrentView = new Views.SettingsView());

            //// Set default view
            //CurrentView = new Views.DashboardView();
        }
        private void Navigate(string? pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName)) return;

            switch (pageName)
            {
                case "Dashboard":
                    var dashboardVM = new DashboardViewModel();
                    var dashboardView = new DashboardUC { DataContext = dashboardVM };
                    CurrentView = dashboardView;
                    PageHeader = "Dashboard";
                    break;
                default:
                    PageHeader = "Page Not Found";
                    CurrentView = null;
                    break;
            }
        }


        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
