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
            Menu menu = new()
            {
                Contacts = new()
            };
            Contact contact = new();

            menu.Contacts.Add(contact);

            Assert.AreEqual(1, menu.Contacts.Count);
        }

        public void Should_Remove_Contact_From_List()
        {
            Menu menu = new()
            {
                Contacts = new()
            };
            Contact contact = new();
            menu.Contacts.Add(contact);

            menu.Contacts.Remove(contact);

            Assert.AreEqual(1, menu.Contacts.Count - 1);
        }
    }
}