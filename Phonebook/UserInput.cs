namespace Phonebook;

internal class UserInput
{
    internal static string GetMainMenuInput()
    {
        Console.WriteLine(new String('-', 10));
        Console.WriteLine("PHONEBOOK");
        Console.WriteLine(new String('-', 10));

        Console.WriteLine("\n1. add contact\n2. view contact\n3. update contact\n4. delete contact\n0. Exit app\n\nchoose option:");

        var mainMenuInput = Console.ReadLine().Trim();

        while (!ValidationEngine.ValidMainMenuInput(mainMenuInput))
        {
            Console.WriteLine("\ninvalid input, try again:");
            mainMenuInput = Console.ReadLine().Trim();
        }

        return mainMenuInput;
    }

    internal static string GetName()
    {
        Console.Clear();

        Console.WriteLine("enter name:");

        var name = Console.ReadLine().Trim();

        while (!ValidationEngine.ValidName(name))
        {
            Console.WriteLine("\ninvalid input, enter name:");
            name = Console.ReadLine().Trim();
        }

        return name;
    }

    internal static string GetEmail()
    {
        Console.Clear();
        Console.WriteLine("enter email:");

        var email = Console.ReadLine().Trim();

        while (!ValidationEngine.ValidEmail(email))
        {
            Console.WriteLine("\ninvalid input, enter email:");
            email = Console.ReadLine().Trim();
        }

        return email;
    }
}
