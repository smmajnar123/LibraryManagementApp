using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LibraryManagementApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private object? _currentView;
        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        private string _pageHeader = "Dashboard";
        public string PageHeader
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public System.Windows.Input.ICommand ShowDashboardCommand { get; }
        public System.Windows.Input.ICommand ShowBooksCommand { get; }
        public System.Windows.Input.ICommand ShowBorrowRecordsCommand { get; }
        public System.Windows.Input.ICommand ShowMembersCommand { get; }
        public System.Windows.Input.ICommand ShowSettingsCommand { get; }

        public MainWindowViewModel()
        {
            // Initialize commands
            //ShowDashboardCommand = new RelayCommand(o => CurrentView = new Views.DashboardView());
            //ShowBooksCommand = new RelayCommand(o => CurrentView = new Views.BooksView());
            //ShowBorrowRecordsCommand = new RelayCommand(o => CurrentView = new Views.BorrowRecordsView());
            //ShowMembersCommand = new RelayCommand(o => CurrentView = new Views.MembersView());
            //ShowSettingsCommand = new RelayCommand(o => CurrentView = new Views.SettingsView());

            //// Set default view
            //CurrentView = new Views.DashboardView();
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
