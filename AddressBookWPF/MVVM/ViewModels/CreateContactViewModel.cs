using AddressBook.Services;
using AddressBookWPF.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWPF.MVVM.ViewModels
{
    public partial class CreateContactViewModel : ObservableObject
    {
        private readonly FileService file;
        public CreateContactViewModel()
        {
            file = new FileService();
        }

        [ObservableProperty]
        private string title = "Add Contact";

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
        private void Create()
        {
            file.AddToList(new ContactModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                StreetName = StreetName,
                PostalCode = PostalCode,
                City = City
            });
            Clear();
        }

        private void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            StreetName = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
        }
    }
}
