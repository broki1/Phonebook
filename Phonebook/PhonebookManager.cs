using Phonebook.Data;
using Phonebook.Model;

namespace Phonebook;

internal class PhonebookManager
{
    private static PhonebookContext context = new();

    internal static void AddContact()
    {
        var name = UserInput.GetName();
        var email = UserInput.GetEmail();
        var phoneNumer = UserInput.GetPhoneNumber();

        var contact = new Contact
        {
            Name = name,
            Email = email,
            PhoneNumber = phoneNumer
        };

        context.Contacts.Add(contact);

        var result = context.SaveChanges();

        if (result == 1)
        {
            Console.WriteLine("\ncontact added\npress any key to continue");
        }
        else
        {
            Console.WriteLine("\ncontact not added\npress any key to continue");
        }

        Console.ReadKey();
    }

    internal static void ReadContact()
    {
        var input = UserInput.GetReadInput();

        var contacts = context.Contacts.Where(x => x.Name.Contains(input) ||  x.Email.Contains(input) || x.PhoneNumber.Contains(input))
            .ToList();

        if (contacts == null || contacts.Count == 0)
        {
            Console.WriteLine("\nno contacts found");
        }
        else
        {
            VisualizationTool.PrintContacts(contacts);
        }

        Console.WriteLine("\npress any key to continue");
        Console.ReadKey();
    }

    internal static void UpdateContact()
    {
        VisualizationTool.PrintContacts(context.Contacts.ToList());

        var contactID = UserInput.GetContactID();

        var contact = context.Contacts.Where(x => x.Id == contactID).ToList();

        VisualizationTool.PrintContacts(contact);

        UserInput.GetUpdate(contact[0]);

        context.SaveChanges();

        Console.WriteLine("\ncontact updated\n\npress any key to continue");
        Console.ReadKey();
    }
    internal static void DeleteContact()
    {
        VisualizationTool.PrintContacts(context.Contacts.ToList());

        var contactID = UserInput.GetContactID();

        var contact = context.Contacts.Where(x => x.Id == contactID).First();

        Console.WriteLine("\nare you sure you want to delete this contact? press '1' to confirm, press '0' to cancel");

        var userChoice = UserInput.GetUpdateChoice();

        if (userChoice == "1")
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            Console.WriteLine("\ncontact deleted");
        }
        else
        {
            Console.WriteLine("\ncancelled");
        }

        Console.WriteLine("\n\npress any key to continue");
        Console.ReadKey();
    }
}
