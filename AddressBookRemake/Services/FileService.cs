using AddressBookRemake.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AddressBookRemake.Services
{
    public class FileService
    {
        private readonly string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json";
        private List<Contact> contacts = new();

        public FileService()
        {
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(path);
                contacts = JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd())!;
            }
            catch { contacts = new List<Contact>(); }
        }

        public ObservableCollection<Contact> Contacts()
        {
            var items = new ObservableCollection<Contact>();
            foreach (var contact in contacts)
                items.Add(contact);
            return items;
        }

        public void SaveToFile()
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }

        public void AddToList(Contact contact)
        {
            contacts.Add(contact);
            SaveToFile();
        }

        public void EditFromList(Contact contact)
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
                SaveToFile();
            }
            else
                MessageBox.Show("Could not find contact.");
        }

        public void RemoveFromList(Contact contact)
        {
            contacts.Remove(contact);
            SaveToFile();
        }
    }
}
