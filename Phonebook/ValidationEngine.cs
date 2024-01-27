
using System.Net.Mail;

namespace Phonebook;

internal class ValidationEngine
{
    internal static bool ValidMainMenuInput(string mainMenuInput)
    {
        bool valid = false;

        switch (mainMenuInput)
        {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
                valid = true; break;
            default:
                break;
        }

        return valid;
    }

    internal static bool ValidName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        return true;
    }

    internal static bool ValidEmail(string emailInput)
    {
        bool valid = true;

        try
        {
            new MailAddress(emailInput);
        }
        catch
        {
            valid = false;
        }

        return valid;
    }
}