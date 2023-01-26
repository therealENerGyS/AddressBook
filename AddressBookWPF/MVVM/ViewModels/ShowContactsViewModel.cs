using AddressBook.Services;
using AddressBookWPF.MVVM.Models;
using AddressBookWPF.MVVM.Views;
using AddressBookWPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class ShowContactsViewModel : ObservableObject
    {

        [ObservableProperty]
        private string title = "Contact List";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();


        [ObservableProperty]
        private string firstName = string.Empty;
        [ObservableProperty]
        private string lastName = string.Empty;
        [ObservableProperty]
        private string email = string.Empty;
        [ObservableProperty]
        private string phoneNumber = string.Empty;
        [ObservableProperty]
        private string streetName = string.Empty;
        [ObservableProperty]
        private string postalCode = string.Empty;
        [ObservableProperty]
        private string city = string.Empty;

    }
}
