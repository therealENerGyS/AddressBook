using AddressBook.Services;
using AddressBookWPF.MVVM.Models;
using AddressBookWPF.MVVM.Views;
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
        private readonly FileService file;
        public ShowContactsViewModel()
        {
            file = new FileService();
            contacts = file.Contacts();
        }

        [ObservableProperty]
        private string title = "Contact List";

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

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

        [RelayCommand]
        private void Remove(ContactModel contact)
        {
            file.RemoveFromList(contact);
        }
    }
}
