using AddressBookRemake.Models;
using AddressBookRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace AddressBookRemake.ViewModels
{
    public partial class ShowContactsViewModel : ObservableObject
    {
        private readonly FileService file;

        [ObservableProperty]
        private ObservableCollection<Contact> contacts = new();

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
    }
}
