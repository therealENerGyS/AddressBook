namespace AddressBook.Models
{
    internal class Contact
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public int PostalCode { get; set; }
    }
}
