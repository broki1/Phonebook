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

}
