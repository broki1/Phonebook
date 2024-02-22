namespace Phonebook;

internal class Program
{
    static void Main(string[] args)
    {
        bool exitApp = false;

        while (!exitApp)
        {
            Console.Clear();

            var userInput = UserInput.GetMainMenuInput();

            switch (userInput)
            {
                case "0":
                    exitApp = true;
                    break;
                case "1":
                    PhonebookManager.AddContact();
                    break;
                case "2":
                    PhonebookManager.ReadContact();
                    break;
                case "3":
                    PhonebookManager.UpdateContact();
                    break;
                case "4":
                    PhonebookManager.DeleteContact();
                    break;
                case "5":
                    Console.WriteLine("Enter email");
                    var email = Console.ReadLine().Trim();

                    Console.WriteLine("Enter subject");
                    var subject = Console.ReadLine().Trim();

                    Console.WriteLine("Enter body");
                    var body = Console.ReadLine().Trim();

                    EmailController.SendEmail(subject, body, email);
                    break;
                default:
                    Console.WriteLine("\ninvalid input");
                    break;
            }
        }
    }
}
