using AddressBookWPF.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Documents;

namespace AddressBook.Services
{
    internal class FileService
    {
        private readonly string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
        private List<ContactModel> contacts;

        public FileService()
        {
            Read();
        }
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
                contacts = JsonConvert.DeserializeObject<List<ContactModel>>(sr.ReadToEnd())!;
            }
            catch { contacts = new List<ContactModel>(); }
        }
        public void AddToList(ContactModel contact)
        {
            contacts.Add(contact);
            Save();
        }
        public void RemoveFromList(ContactModel contact)
        {
            File.ReadAllLines(filePath);
            foreach (List<string> line in File.ReadAllLines(filePath))
            {
                filePath.Remove(line);
            }
            File.WriteAllLines($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\temp.json", linesToRemove);

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
