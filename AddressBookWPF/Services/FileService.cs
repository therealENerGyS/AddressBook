using AddressBookWPF.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows;

namespace AddressBook.Services
{
    public class FileService
    {
        private readonly string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
        private List<ContactModel> contacts = new();

        public FileService() => Read();

        private void Read()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                contacts = JsonConvert.DeserializeObject<List<ContactModel>>(sr.ReadToEnd())!;
            }
            catch { contacts = new List<ContactModel>(); }
        }

        public void Save()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }
        public void AddToList(ContactModel contact)
        {
            contacts.Add(contact);
            Save();
        }
        public void RemoveFromList(ContactModel contact)
        {
            contacts.Remove(contact);
            Save();
        }

        public void EditFromList(ContactModel contact)
        {
            var editContact = contacts.FirstOrDefault(x => x.FirstName == contact.FirstName && x.LastName == contact.LastName);
            if (editContact != null)
            {
                editContact.FirstName = contact.FirstName;
                editContact.LastName = contact.LastName;
                editContact.Email = contact.Email;
                editContact.PhoneNumber = contact.PhoneNumber;
                editContact.PostalCode = contact.PostalCode;
                editContact.City = contact.City;
                Save();
            }
            else
                MessageBox.Show("Could not find contact.");
        }

        public ObservableCollection<ContactModel> Contacts()
        {
            var items = new ObservableCollection<ContactModel>();
            foreach (var contact in contacts)
                items.Add(contact);
            return items;
        }
    }
}
