using AddressBookRemake.Models;
using AddressBookRemake.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AddressBookRemake.Views
{
    /// <summary>
    /// Interaction logic for ShowContacts.xaml
    /// </summary>
    public partial class ShowContacts : UserControl
    {
        private readonly FileService file;
        public ObservableCollection<Contact> contacts { get; set; }
        public ShowContacts()
        {
            InitializeComponent();
            file = new FileService();
            contacts = (ObservableCollection<Contact>)file.Contacts();

            lv_ContactList.ItemsSource = contacts;
        }

        private void Lv_ContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Contact item in lv_ContactList.Items)
            {
                if (lv_ContactList.SelectedItem == item)
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


        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var selectedContact = lv_ContactList.SelectedItem as Contact;
            if (selectedContact != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete this contact?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    file.RemoveFromList(selectedContact);
                    lv_ContactList.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please select a contact to delete.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
