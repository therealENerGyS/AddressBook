using AddressBook.Models;
using AddressBook.Services;

namespace AddressBook.Tests
{
    [TestClass]
    public class AddressBook_Tests
    {
        [TestMethod]
        public void Should_Add_Contact_To_List()
        {
            Menu menu = new Menu();
            menu.Contacts = new List<Contact>();
            Contact contact = new Contact();

            menu.Contacts.Add(contact);

            Assert.AreEqual(1, menu.Contacts.Count);
        }
    }
}