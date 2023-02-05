using CommunityToolkit.Mvvm.ComponentModel;

namespace AddressBookRemake.ViewModels
{
    public partial class CreateContactViewModel : ObservableObject
    {

        [ObservableProperty]
        private string title = "Add Contact";

        [ObservableProperty]
        private string firstName = string.Empty;
        [ObservableProperty]
        private string lastName = string.Empty;
        [ObservableProperty]
        private string email = string.Empty;
        [ObservableProperty]
        private string phoneNumber = string.Empty;
        [ObservableProperty]
        private string streetName = string.Empty;
        [ObservableProperty]
        private string postalCode = string.Empty;
        [ObservableProperty]
        private string city = string.Empty;
    }
}
