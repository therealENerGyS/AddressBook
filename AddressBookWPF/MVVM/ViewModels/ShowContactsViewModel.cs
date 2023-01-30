﻿using AddressBook.Services;
using AddressBookWPF.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

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
        private ObservableCollection<ContactModel> contacts = new();

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


        [RelayCommand]
        private void RemoveContact(ContactModel contact)
        {
            MessageBox.Show($"Are you sure you wish to delete this contact: {contact.DisplayName}");
            file.RemoveFromList(contact);
        }

        [RelayCommand]
        private void UpdateContact(ContactModel contact)
        {
            MessageBox.Show($"Are you sure you wish to update this contact: {contact.DisplayName}");
            file.EditFromList(contact);
        }
    }
}
