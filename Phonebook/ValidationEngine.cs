
using PhoneNumbers;
using System.Globalization;
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

    internal static bool ValidCountryCode(string countryCodeInput)
    {
        try
        {
            new RegionInfo(countryCodeInput);
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal static bool ValidPhoneNumber(string phoneNumber, string countryCode)
    {
        // implements libphonenumber library
        var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();

        // checks if PhoneNumber can be created and if the PhoneNumber object is valid, if not, then not valid phone number and returns false
        try
        {
            PhoneNumber phoneNumberObj = phoneNumberUtil.Parse(phoneNumber, countryCode);

            return phoneNumberUtil.IsValidNumber(phoneNumberObj);
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}