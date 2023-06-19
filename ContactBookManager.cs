using ContactBook.Models;

namespace ContactBook
{
    public class ContactBookManager
    {
        private List<Contact> contacts;

        public ContactBookManager()
        {
            contacts = new List<Contact>
        {
            new Contact
            {
                Name = "John Doe",
                PhoneNumber = "1234567890",
                EmailAddress = "johndoe@example.com"
            },
            new Contact
            {
                Name = "Jane Smith",
                PhoneNumber = "9876543210",
                EmailAddress = "janesmith@example.com"
            }
        };
        }

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Contact Book");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Delete Contact");
                Console.WriteLine("3. View Contacts");
                Console.WriteLine("4. Update Contact");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        DeleteContact();
                        break;
                    case "3":
                        ViewContacts();
                        break;
                    case "4":
                        UpdateContact();
                        break;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("Exiting the Contact Book.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine(); // Add a line break for readability
            }
        }

        private void AddContact()
        {
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter the email address: ");
            string emailAddress = Console.ReadLine();

            Contact newContact = new Contact
            {
                Name = name,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress
            };

            contacts.Add(newContact);
            Console.WriteLine("Contact added successfully!");
        }

        private void DeleteContact()
        {
            Console.Write("Enter contact ID: ");
            string contactId = Console.ReadLine();

            if (!string.IsNullOrEmpty(contactId) && contacts.Exists(x => x.Id.ToString() == contactId))
            {
                Contact deletedContact = contacts.FirstOrDefault(x => x.Id.ToString() == contactId);
                contacts.RemoveAll(x => x.Id.ToString() == contactId);

                if (deletedContact != null)
                {
                    Console.WriteLine($"Contact {deletedContact.Name} deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Error: Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Contact not found or invalid contact ID.");
            }
        }

        private void UpdateContact()
        {
            Console.Write("Enter contact ID: ");
            string contactId = Console.ReadLine();

            if (!string.IsNullOrEmpty(contactId) && contacts.Exists(x => x.Id.ToString() == contactId))
            {
                Contact toBeUpdatedContact = contacts.FirstOrDefault(x => x.Id.ToString() == contactId);
                if (toBeUpdatedContact != null)
                {
                    // Perform the update operation on the contact
                    Console.WriteLine("Enter updated contact details:");
                    Console.Write("Name: ");
                    toBeUpdatedContact.Name = Console.ReadLine();

                    Console.Write("Phone Number: ");
                    toBeUpdatedContact.PhoneNumber = Console.ReadLine();

                    Console.Write("Email Address: ");
                    toBeUpdatedContact.EmailAddress = Console.ReadLine();

                    Console.WriteLine("Contact updated successfully!");
                }
            }
        }

        private void ViewContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                Console.WriteLine("Contacts:\n");
                foreach (var contact in contacts)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine($"ID: {contact.Id}");
                    Console.WriteLine($"Name: {contact.Name}");
                    Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                    Console.WriteLine($"Email Address: {contact.EmailAddress}");
                    Console.WriteLine("-------------------------\n");
                }
            }
        }
    }
}