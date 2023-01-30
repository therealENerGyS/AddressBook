using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookRemake.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentVM;

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
