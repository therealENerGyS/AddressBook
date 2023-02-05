using AddressBookRemake.Models;
using AddressBookRemake.Services;
using System.Windows;
using System.Windows.Controls;

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
            OnWindowLoad();
        }


        private void OnWindowLoad()
        {
            Lv_ContactList.ItemsSource = file.Contacts();

            btn_Cancel.Visibility = Visibility.Hidden;
            btn_Confirm.Visibility = Visibility.Hidden;
            btn_Edit.Visibility = Visibility.Hidden;
            btn_Remove.Visibility = Visibility.Hidden;

            l_FirstName.Visibility = Visibility.Hidden;
            l_LastName.Visibility = Visibility.Hidden;
            l_Email.Visibility = Visibility.Hidden;
            l_PhoneNumber.Visibility = Visibility.Hidden;
            l_StreetName.Visibility = Visibility.Hidden;
            l_PostalCode.Visibility = Visibility.Hidden;
            l_City.Visibility = Visibility.Hidden;
        }

        private void Lv_ContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Contact item in Lv_ContactList.Items)
            {
                if (Lv_ContactList.SelectedItem == item)
                {
                    tb_FirstName.Text = item.FirstName;
                    tb_LastName.Text = item.LastName;
                    tb_Email.Text = item.Email;
                    tb_PhoneNumber.Text = item.PhoneNumber;
                    tb_StreetName.Text = item.StreetName;
                    tb_PostalCode.Text = item.PostalCode;
                    tb_City.Text = item.City;

                    btn_Edit.Visibility = Visibility.Visible;
                    btn_Remove.Visibility = Visibility.Visible;

                    l_FirstName.Visibility = Visibility.Visible;
                    l_LastName.Visibility = Visibility.Visible;
                    l_Email.Visibility = Visibility.Visible;
                    l_PhoneNumber.Visibility = Visibility.Visible;
                    l_StreetName.Visibility = Visibility.Visible;
                    l_PostalCode.Visibility = Visibility.Visible;
                    l_City.Visibility = Visibility.Visible;
                }
            }
        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var contact = (Contact)Lv_ContactList.SelectedItem;

            MessageBoxResult res = MessageBox.Show("Are you sure you wish to remove this contact?", "Confirmation", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                file.RemoveFromList(contact);

                Lv_ContactList.ItemsSource = file.Contacts();

                tb_FirstName.Text = string.Empty;
                tb_LastName.Text = string.Empty;
                tb_Email.Text = string.Empty;
                tb_PhoneNumber.Text = string.Empty;
                tb_StreetName.Text = string.Empty;
                tb_PostalCode.Text = string.Empty;
                tb_City.Text = string.Empty;
            }
            else { }
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Editable();
        }
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var contact = (Contact)Lv_ContactList.SelectedItem;

            EditComplete();

            for (int i = 0; i < file.Contacts().Count; i++)
            {
                if (file.Contacts()[i].FirstName == contact.FirstName)
                {
                    tb_FirstName.Text = contact.FirstName;
                    tb_LastName.Text = contact.LastName;
                    tb_Email.Text = contact.Email;
                    tb_PhoneNumber.Text = contact.PhoneNumber;
                    tb_StreetName.Text = contact.StreetName;
                    tb_PostalCode.Text = contact.PostalCode;
                    tb_City.Text = contact.City;
                }
            }

            Lv_ContactList.SelectedItem = Lv_ContactList.Items[Lv_ContactList.Items.Count - 1];
        }
        private void Btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            var contact = (Contact)Lv_ContactList.SelectedItem;

            for (int i = 0; i < file.Contacts().Count; i++)
            {
                if (contact.Id == file.Contacts()[i].Id)
                {
                    file.RemoveFromList(contact);

                    file.AddToList(new Contact()
                    {
                        FirstName = tb_FirstName.Text,
                        LastName = tb_LastName.Text,
                        Email = tb_Email.Text,
                        PhoneNumber = tb_PhoneNumber.Text,
                        StreetName = tb_StreetName.Text,
                        PostalCode = tb_PostalCode.Text,
                        City = tb_City.Text
                    });
                }
                else { }
            }
            EditComplete();

            Lv_ContactList.ItemsSource = file.Contacts();
            Lv_ContactList.SelectedItem = Lv_ContactList.Items[Lv_ContactList.Items.Count - 1];
        }

        private void Editable()
        {
            tb_FirstName.IsReadOnly = false;
            tb_LastName.IsReadOnly = false;
            tb_Email.IsReadOnly = false;
            tb_PhoneNumber.IsReadOnly = false;
            tb_StreetName.IsReadOnly = false;
            tb_PostalCode.IsReadOnly = false;
            tb_City.IsReadOnly = false;

            tb_FirstName.BorderThickness = new Thickness(1);
            tb_LastName.BorderThickness = new Thickness(1);
            tb_Email.BorderThickness = new Thickness(1);
            tb_PhoneNumber.BorderThickness = new Thickness(1);
            tb_StreetName.BorderThickness = new Thickness(1);
            tb_PostalCode.BorderThickness = new Thickness(1);
            tb_City.BorderThickness = new Thickness(1);

            Lv_ContactList.Focusable = false;
            Lv_ContactList.IsHitTestVisible = false;

            btn_Edit.Visibility = Visibility.Hidden;
            btn_Remove.Visibility = Visibility.Hidden;

            btn_Cancel.Visibility = Visibility.Visible;
            btn_Confirm.Visibility = Visibility.Visible;

        }

        private void EditComplete()
        {
            tb_FirstName.IsReadOnly = true;
            tb_LastName.IsReadOnly = true;
            tb_Email.IsReadOnly = true;
            tb_PhoneNumber.IsReadOnly = true;
            tb_StreetName.IsReadOnly = true;
            tb_PostalCode.IsReadOnly = true;
            tb_City.IsReadOnly = true;

            tb_FirstName.BorderThickness = new Thickness(0);
            tb_LastName.BorderThickness = new Thickness(0);
            tb_Email.BorderThickness = new Thickness(0);
            tb_PhoneNumber.BorderThickness = new Thickness(0);
            tb_StreetName.BorderThickness = new Thickness(0);
            tb_PostalCode.BorderThickness = new Thickness(0);
            tb_City.BorderThickness = new Thickness(0);

            Lv_ContactList.Focusable = true;
            Lv_ContactList.IsHitTestVisible = true;

            btn_Edit.Visibility = Visibility.Visible;
            btn_Remove.Visibility = Visibility.Visible;

            btn_Cancel.Visibility = Visibility.Hidden;
            btn_Confirm.Visibility = Visibility.Hidden;
        }
    }
}