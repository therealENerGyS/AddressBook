using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBookRemake.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentVM = null!;

        [RelayCommand]
        private void ShowContacts() => CurrentVM = new ShowContactsViewModel();

        [RelayCommand]
        private void CreateContacts() => CurrentVM = new CreateContactViewModel();
        public MainViewModel()
        {
            CurrentVM = new ShowContactsViewModel();
        }
    }
}
