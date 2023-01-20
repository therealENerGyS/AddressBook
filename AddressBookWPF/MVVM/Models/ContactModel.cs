﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWPF.MVVM.Models
{
    public interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string StreetName { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }

    }
    public class ContactModel : IContact
    {
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
