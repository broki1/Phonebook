namespace Phonebook;

internal class PhonebookManager
{

    internal static void AddContact()
    {
        var name = UserInput.GetName();
        var email = UserInput.GetEmail();

        Console.WriteLine(email);
    }

}
