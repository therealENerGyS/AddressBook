using AddressBookWPF.MVVM.Models;
using AddressBookWPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace AddressBook.Services
{
    public class FileService
    {
        private readonly string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();

        public FileService() => Read();

        private void Save()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }
        private void Read()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd())!;
            }
            catch { contacts = ContactService.Contacts(); }
        }
        public void AddToList(ContactModel contact)
        {
            ContactService.AddContact(contact);
            Save();
        }
        public void RemoveFromList(ContactModel contact)
        {
            ContactService.RemoveContact(contact);
            Save();
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
