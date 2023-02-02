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
        private readonly FileService file = new();
        public ShowContacts()
        {
            InitializeComponent();
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

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (Contact)button.DataContext;

            file.RemoveFromList(contact);
        }
    }
}
