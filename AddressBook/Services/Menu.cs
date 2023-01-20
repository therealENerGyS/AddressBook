using AddressBook.Models;
using Newtonsoft.Json;

namespace AddressBook.Services
{
    internal class Menu
    {
        private readonly List<Contact> contacts = new();
        private readonly FileService file = new();
        public string FilePath { get; set; } = null!;

        public void MainMenu()
        {
            Console.Write("Welcome to the Address book, please choose one of the following: \n" +
            "1. Create a Contact. \n" +
            "2. Display all Contacts. \n" +
            "3. Display a specific Contact. \n" +
            "4. Remove a Contact. \n" +
            "0. Quit application. \n");
            int userInput = int.Parse(Console.ReadLine()!);
            Console.Clear();
            switch (userInput)
            {
                case 1: OptionOne(); break;
                case 2: OptionTwo(); break;
                case 3: OptionThree(); break;
                case 4: OptionFour(); break;
                case 0: Exit(); break;
                default: Console.WriteLine("Please choose between 0-4"); break;
            }
        }

        private void OptionOne()
        {
            Contact contact = new();
            Console.Write("Add Contact: \n" +
                "First name: ");
            contact.FirstName = Console.ReadLine()!;
            if (contact.FirstName.Length < 2)
            {
                Console.Write("First name is required.");
                Console.ReadKey();
            }
            Console.Clear();
            Console.Write("Last name: ");
            contact.LastName = Console.ReadLine()!;
            Console.Clear();
            Console.Write("Email: ");
            contact.Email = Console.ReadLine()!;
            Console.Clear();
            Console.Write("Phone number: ");
            contact.PhoneNumber = int.Parse(Console.ReadLine()!);
            Console.Clear();
            Console.Write("Address: ");
            contact.Address = Console.ReadLine()!;
            Console.Clear();
            Console.Write("Postal Code: ");
            contact.PostalCode = int.Parse(Console.ReadLine()!);
            Console.Clear();
            Console.Write("City: ");
            contact.City = Console.ReadLine()!;
            Console.WriteLine($"{contact.FirstName} {contact.LastName} was successfully added to the address book.");
            contacts.Add(contact);
            Console.ReadLine();
            Console.Clear();
            file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
        }

        private void OptionTwo()
        {
            file.Read(FilePath);
            Console.WriteLine("Showing all Contacts.");
            if (contacts.Count > 0)
            {
                foreach (Contact person in contacts)
                {
                    if (person.Email == "")
                    {
                        Console.WriteLine($"{person.FirstName} {person.LastName}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.FirstName} {person.LastName} <{person.Email}>");
                    }

                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty.");
            }
            Console.Clear();
        }

        private void OptionThree()
        {
            if (contacts.Count > 0)
            {
                List<Contact> sameFirstName = new();
                Console.Write("Enter first name of contact: ");
                string userFirstName = Console.ReadLine()!;
                for (int i = 0; i < contacts.Count; i++)
                {
                    if (userFirstName.ToUpper() == contacts[i].FirstName.ToUpper())
                    {
                        sameFirstName.Add(contacts[i]);
                    }
                    else
                    {
                        Console.WriteLine("\nThe Contact you're searching for could not be found. Make sure the contact has been created or the spelling is correct.");
                    }
                }
                if (sameFirstName.Count > 1)
                {
                    Console.Write($"{sameFirstName.Count} contacts were found. For a more specific search type in the last name as well: ");
                    string compareLastName = Console.ReadLine()!;
                    for (int i = 0; i < sameFirstName.Count; i++)
                    {
                        if (compareLastName.ToUpper() == sameFirstName[i].LastName.ToUpper())
                        {
                            Console.Clear();
                            Console.WriteLine($"The Contact was found successfully: \n" +
                            $"First name: {sameFirstName[i].FirstName} \n" +
                            $"Last name: {sameFirstName[i].LastName} \n" +
                            $"Email: {sameFirstName[i].Email} \n" +
                            $"Phone number: {sameFirstName[i].PhoneNumber} \n" +
                            $"Address: {sameFirstName[i].Address}, {sameFirstName[i].PostalCode} {sameFirstName[i].City}");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < sameFirstName.Count; i++)
                    {
                        if (contacts[i].Email.Length == 0)
                        {
                            if (contacts[i].PhoneNumber == 0)
                            {
                                if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName}");
                                }
                                else
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName} \n" +
                                    $"Address: {sameFirstName[i].Address}, {sameFirstName[i].PostalCode} {sameFirstName[i].City}");
                                }
                            }
                            else if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                            {
                                if (contacts[i].PhoneNumber == 0)
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName}");
                                }
                                else
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName} \n" +
                                    $"Phone number: {sameFirstName[i].PhoneNumber}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {sameFirstName[i].FirstName} \n" +
                                $"Last name: {sameFirstName[i].LastName} \n" +
                                $"Phone number: {sameFirstName[i].PhoneNumber} \n" +
                                $"Address: {sameFirstName[i].Address}, {sameFirstName[i].PostalCode} {sameFirstName[i].City}");
                            }
                        }
                        else if (contacts[i].PhoneNumber == 0)
                        {
                            if (contacts[i].Email.Length == 0)
                            {
                                if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName} \n");
                                }
                                else
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName} \n" +
                                    $"Address: {sameFirstName[i].Address}, {sameFirstName[i].PostalCode} {sameFirstName[i].City}");
                                }
                            }
                            else if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                            {
                                if (contacts[i].Email.Length == 0)
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName}");
                                }
                                else
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName} \n" +
                                    $"Email: {sameFirstName[i].Email}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {sameFirstName[i].FirstName} \n" +
                                $"Last name: {sameFirstName[i].LastName} \n" +
                                $"Email: {sameFirstName[i].Email} \n" +
                                $"Address: {sameFirstName[i].Address}, {sameFirstName[i].PostalCode} {sameFirstName[i].City}");
                            }
                        }
                        else if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                        {
                            if (contacts[i].PhoneNumber == 0)
                            {
                                if (contacts[i].Email.Length == 0)
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName}");
                                }
                                else
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName} \n" +
                                    $"Email: {sameFirstName[i].Email}");
                                }
                            }
                            else if (contacts[i].Email.Length == 0)
                            {
                                if (contacts[i].PhoneNumber == 0)
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName}");
                                }
                                else
                                {
                                    Console.WriteLine($"The Contact was found successfully: \n" +
                                    $"First name: {sameFirstName[i].FirstName} \n" +
                                    $"Last name: {sameFirstName[i].LastName} \n" +
                                    $"Phone number: {sameFirstName[i].PhoneNumber}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {sameFirstName[i].FirstName} \n" +
                                $"Last name: {sameFirstName[i].LastName} \n" +
                                $"Email: {sameFirstName[i].Email} \n" +
                                $"Phone number: {sameFirstName[i].PhoneNumber}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"The Contact was found successfully: \n" +
                            $"First name: {sameFirstName[i].FirstName} \n" +
                            $"Last name: {sameFirstName[i].LastName} \n" +
                            $"Email: {sameFirstName[i].Email} \n" +
                            $"Phone number: {sameFirstName[i].PhoneNumber} \n" +
                            $"Address: {sameFirstName[i].Address}, {sameFirstName[i].PostalCode} {sameFirstName[i].City}");
                        }
                    }
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\nThe Address book is empty. Please add a contact first.");
            }
            Console.Clear();
        }

        private void OptionFour()
        {
            Console.WriteLine("Contact Removal \n" +
                "Type in the first name of the contact: ");
            string removeFirstName = Console.ReadLine()!;
            List<Contact> removeSameFirstName = new();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (removeFirstName.ToUpper() == contacts[i].FirstName.ToUpper())
                {
                    removeSameFirstName.Add(contacts[i]);
                }
                else
                {
                    Console.WriteLine("\nThe Contact you're searching for could not be found. Make sure the contact has been created or the spelling is correct.");
                }
            }
            if (removeSameFirstName.Count > 1)
            {
                Console.Write($"{removeSameFirstName.Count} contacts were found. For a more specific search type in the last name as well: ");
                string compareLastName = Console.ReadLine()!;
                for (int i = 0; i < removeSameFirstName.Count; i++)
                {
                    if (compareLastName.ToUpper() == removeSameFirstName[i].LastName.ToUpper())
                    {
                        Console.Clear();
                        Console.WriteLine($"The Contact was found successfully: \n" +
                        $"First name: {removeSameFirstName[i].FirstName} \n" +
                        $"Last name: {removeSameFirstName[i].LastName} \n" +
                        $"Email: {removeSameFirstName[i].Email} \n" +
                        $"Phone number: {removeSameFirstName[i].PhoneNumber} \n" +
                        $"Address: {removeSameFirstName[i].Address}, {removeSameFirstName[i].PostalCode} {removeSameFirstName[i].City}");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                for (int i = 0; i < removeSameFirstName.Count; i++)
                {
                    if (contacts[i].Email.Length == 0)
                    {
                        if (contacts[i].PhoneNumber == 0)
                        {
                            if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName}");
                            }
                            else
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName} \n" +
                                $"Address: {removeSameFirstName[i].Address}, {removeSameFirstName[i].PostalCode} {removeSameFirstName[i].City}");
                            }
                        }
                        else if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                        {
                            if (contacts[i].PhoneNumber == 0)
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName}");
                            }
                            else
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName} \n" +
                                $"Phone number: {removeSameFirstName[i].PhoneNumber}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"The Contact was found successfully: \n" +
                            $"First name: {removeSameFirstName[i].FirstName} \n" +
                            $"Last name: {removeSameFirstName[i].LastName} \n" +
                            $"Phone number: {removeSameFirstName[i].PhoneNumber} \n" +
                            $"Address: {removeSameFirstName[i].Address}, {removeSameFirstName[i].PostalCode} {removeSameFirstName[i].City}");
                        }
                    }
                    else if (contacts[i].PhoneNumber == 0)
                    {
                        if (contacts[i].Email.Length == 0)
                        {
                            if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName} \n");
                            }
                            else
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName} \n" +
                                $"Address: {removeSameFirstName[i].Address}, {removeSameFirstName[i].PostalCode} {removeSameFirstName[i].City}");
                            }
                        }
                        else if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                        {
                            if (contacts[i].Email.Length == 0)
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName}");
                            }
                            else
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName} \n" +
                                $"Email: {removeSameFirstName[i].Email}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"The Contact was found successfully: \n" +
                            $"First name: {removeSameFirstName[i].FirstName} \n" +
                            $"Last name: {removeSameFirstName[i].LastName} \n" +
                            $"Email: {removeSameFirstName[i].Email} \n" +
                            $"Address: {removeSameFirstName[i].Address}, {removeSameFirstName[i].PostalCode} {removeSameFirstName[i].City}");
                        }
                    }
                    else if (contacts[i].Address.Length == 0 || contacts[i].PostalCode < 1 || contacts[i].City.Length == 0)
                    {
                        if (contacts[i].PhoneNumber == 0)
                        {
                            if (contacts[i].Email.Length == 0)
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName}");
                            }
                            else
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName} \n" +
                                $"Email: {removeSameFirstName[i].Email}");
                            }
                        }
                        else if (contacts[i].Email.Length == 0)
                        {
                            if (contacts[i].PhoneNumber == 0)
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName}");
                            }
                            else
                            {
                                Console.WriteLine($"The Contact was found successfully: \n" +
                                $"First name: {removeSameFirstName[i].FirstName} \n" +
                                $"Last name: {removeSameFirstName[i].LastName} \n" +
                                $"Phone number: {removeSameFirstName[i].PhoneNumber}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"The Contact was found successfully: \n" +
                            $"First name: {removeSameFirstName[i].FirstName} \n" +
                            $"Last name: {removeSameFirstName[i].LastName} \n" +
                            $"Email: {removeSameFirstName[i].Email} \n" +
                            $"Phone number: {removeSameFirstName[i].PhoneNumber}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"The Contact was found successfully: \n" +
                        $"First name: {removeSameFirstName[i].FirstName} \n" +
                        $"Last name: {removeSameFirstName[i].LastName} \n" +
                        $"Email: {removeSameFirstName[i].Email} \n" +
                        $"Phone number: {removeSameFirstName[i].PhoneNumber} \n" +
                        $"Address: {removeSameFirstName[i].Address}, {removeSameFirstName[i].PostalCode} {removeSameFirstName[i].City}");
                    }
                    Console.WriteLine("Are you sure you wish to remove this contact? [Y/N]");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        contacts.Remove(removeSameFirstName[i]);
                        Console.WriteLine("The Contact has been removed.");
                        Console.ReadKey();
                        break;
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.N)
                    {
                        Console.WriteLine("The Contact was not removed");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
