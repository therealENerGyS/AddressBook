using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        [RelayCommand]
        private void CreateContact() => CurrentViewModel = new CreateContactViewModel();
        [RelayCommand]
        private void ShowContacts() => CurrentViewModel = new ShowContactsViewModel();
        public MainViewModel()
        {
            CurrentViewModel = new ShowContactsViewModel();
        }
    }
}
