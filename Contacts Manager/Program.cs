using System;
using System.Collections.Generic;

namespace ContactsManager
{
    public class Program
    {
        private static List<Contact> Contacts = new List<Contact>();

        public static void Main(string[] args)
        {
            ContactsManager();
        }

        public static void ContactsManager()
        {
            Console.WriteLine("\n \t \t \t \t Welcome to Contact Manager App !\nPlease select a service to begin:\n");

            bool flag = true;

            while (flag)
            {
                Console.WriteLine(" To Add New Contact Select 'A'.\n To Delete a Contact Select 'D'.\n To View All Contacts Select 'V'\n To End The App Select 'E'. ");

                string input = GetUserInput().ToUpper(); 

                if (!string.IsNullOrEmpty(input) && (input == "A" || input == "D" || input == "V" || input == "E"))
                {
                    Services(input);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n Invalid Input!! You Should Write a Valid Service.\n ");
                }
            }
        }

        public static void Services(string input)
        {
            switch (input)
            {
                case "A":
                    Console.WriteLine("\n Enter contact name:");
                    string nameToAdd = GetUserInput();
                    Console.WriteLine("Enter contact mobile phone number:");
                    string phoneNumberToAdd = GetUserInput();
                    Console.WriteLine(AddContact(nameToAdd, phoneNumberToAdd));
                    break;

                case "D":
                    Console.WriteLine("\n Enter contact name to delete:");
                    string nameToDelete = GetUserInput();
                    Console.WriteLine(RemoveContact(nameToDelete));
                    break;

                case "V":
                    ViewContacts();
                    break;

                case "E":
                    End();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\n Invalid input. Please enter A, D, V, or E.");
                    break;
            }
        }

        public static string AddContact(string userName, string phoneNumber)
        {
            Console.WriteLine("\n");

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.Clear();
                Console.WriteLine("\n");
                return "Invalid name or phone number. Contact not added. \n";
            }

            if (Contacts.Exists(c => c.Name.Equals(userName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\n");
                return $"Contact with name '{userName}' already exists.";
            }
            else
            {
                Console.WriteLine("\n");
                Contacts.Add(new Contact { Name = userName, PhoneNumber = phoneNumber });
                return $"Contact '{userName}' added successfully.";
            }


        }

        public static string RemoveContact(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.Clear();
                Console.WriteLine("\n");
                return "Invalid contact name.";
            }

            var contactToRemove = Contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contactToRemove != null)
            {
                Contacts.Remove(contactToRemove);
                Console.WriteLine("\n");
                return $"Contact '{name}' removed successfully.";
            }
            else
            {
                return $"Contact '{name}' does not exist.";
            }
        }

        public static void ViewContacts()
        {
            Console.WriteLine("\n All Contacts:");

            if (Contacts.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No contacts found.");
            }
            else
            {
                foreach (var contact in Contacts)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}");
                }
            }
        }

        public static void End()
        {
            Console.Clear();
            Console.WriteLine("Exiting Contact Manager App.");
            Environment.Exit(0);
        }

        // Helper method to get user input
        public static string GetUserInput()
        {
            return Console.ReadLine()?.Trim();
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
