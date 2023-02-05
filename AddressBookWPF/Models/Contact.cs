using System;

namespace AddressBookRemake.Models
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
        public string DisplayName => $"{FirstName} {LastName} <{Email}>";
        public string Address => $"{StreetName}, {PostalCode} {City}";
    }
}
