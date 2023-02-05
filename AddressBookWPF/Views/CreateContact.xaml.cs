using AddressBookRemake.Models;
using AddressBookRemake.Services;
using System.Windows;
using System.Windows.Controls;

namespace AddressBookRemake.Views
{
    /// <summary>
    /// Interaction logic for CreateContact.xaml
    /// </summary>
    public partial class CreateContact : UserControl
    {
        private readonly FileService file;
        public CreateContact()
        {
            InitializeComponent();
            file = new FileService();
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
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
