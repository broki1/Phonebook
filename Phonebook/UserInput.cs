using PhoneNumbers;
using System.Globalization;

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

    internal static string GetPhoneNumber()
    {
        Console.Clear();
        Console.WriteLine("enter 2-letter country code ('US', 'CH', 'DE', etc.):");
        var countryCode = Console.ReadLine().Trim().ToUpper();
        
        while (!ValidationEngine.ValidCountryCode(countryCode))
        {
            Console.WriteLine("\ninvalid input, enter 2-letter country code ('US', 'CH', 'DE', etc.):");
            countryCode = Console.ReadLine().Trim().ToUpper();
        }

        Console.WriteLine("enter phone number:");
        var phoneNumberInput = Console.ReadLine().Trim();

        while (!ValidationEngine.ValidPhoneNumber(phoneNumberInput, countryCode))
        {
            Console.WriteLine("\ninvalid input, enter phone number:");
            phoneNumberInput = Console.ReadLine().Trim();
        }

        var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        var phoneNumber = phoneNumberUtil.Parse(phoneNumberInput, countryCode);

        return phoneNumberUtil.Format(phoneNumber, PhoneNumberFormat.INTERNATIONAL);
    }

    internal static string GetReadInput()
    {
        Console.Clear();
        Console.WriteLine("search contact:");

        var contactInfo = Console.ReadLine().Trim();

        return contactInfo;
    }
}
