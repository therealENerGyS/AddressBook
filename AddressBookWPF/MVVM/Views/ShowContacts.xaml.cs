using AddressBook.Services;
using AddressBookWPF.MVVM.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace AddressBookWPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ShowContacts.xaml
    /// </summary>
    public partial class ShowContacts : UserControl
    {
        private readonly FileService file;
        public ShowContacts()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ContactModel item in lv_ContactList.Items)
            {
                if(lv_ContactList.SelectedItem == item)
                {
                    tb_FirstName.Text = item.FirstName;
                    tb_LastName.Text = item.LastName;
                    tb_Email.Text = item.Email;
                    tb_PhoneNumber.Text = item.PhoneNumber;
                    tb_StreetName.Text = item.StreetName;
                    tb_PostalCode.Text = item.PostalCode;
                    tb_City.Text = item.City;
                }
            }
        }
        
        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = button.DataContext as ContactModel;

            MessageBox.Show($"Are you sure you wish to delete this contact: {contact!.DisplayName}");
            file.RemoveFromList(contact);
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var selectedContact = lv_ContactList.SelectedItem as ContactModel;
            if(selectedContact != null)
            {
                selectedContact.FirstName = tb_FirstName.Text;
                selectedContact.LastName = tb_LastName.Text;
                selectedContact.Email = tb_Email.Text;
                selectedContact.PhoneNumber = tb_PhoneNumber.Text;
                selectedContact.StreetName = tb_StreetName.Text;
                selectedContact.PostalCode = tb_PostalCode.Text;
                selectedContact.City = tb_City.Text;
                file.Save();
            }

            tb_FirstName.Text = string.Empty;
            tb_LastName.Text = string.Empty;
            tb_Email.Text = string.Empty;
            tb_PhoneNumber.Text = string.Empty;
            tb_StreetName.Text = string.Empty;
            tb_PostalCode.Text = string.Empty;
            tb_City.Text = string.Empty;

        }
    }
}
