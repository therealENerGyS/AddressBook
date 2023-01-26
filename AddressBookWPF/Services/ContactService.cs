using AddressBookWPF.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWPF.Services
{
    public static class ContactService
    {
        private static ObservableCollection<ContactModel> contacts = new();

        public static void AddContact(ContactModel contact)
        {
            contacts.Add(contact);
        }
        public static void RemoveContact(ContactModel contact)
        {
            contacts.Remove(contact);
        }
        public static ObservableCollection<ContactModel> Contacts()
        {
            return contacts;
        }
    }
}
