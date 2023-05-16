using System;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Buffers.Text;
using Multiuser_Ha;

// Khai Ha
// IT112
// Start with making a bank class then a user class. Welcome and Prompt users, stating initial balance in Bank class. Creating a int options, and a CurUserID to track who's using the system
// Enter a while loop, with no ending parameters using different paths to break the loop. Starts with the loop with the user id of null basically, and while it's null we'll keep prompting for log in.
// Options will equal one while we're lock in a loop of checking of a valid log in. If a valid log in is entered, we changed CurUserId to the correct user from the array of users in bank.cs from the login method.
// If an invalid login didn’t receive a valid input it returns a -1 which tells program.cs to say invalid user and prompt for login again.
// We use switch expression to evaluate our input. It captures what option the user enters, then we int parse the input into options, then go down the right paths.
// As a whole, it’s just loops, embedded in loops, that calls onto functions from Bank.cs


namespace Multiuser_Ha
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Console.WriteLine("Welcome to OPP Bank");
            Console.WriteLine($"Bank initial balance: {bank.BankBalance:C}");
            Console.WriteLine("Enter options with corresponding numbers");
            int option;
            int CurUserID = -1;

            while (true)
            {
                if (CurUserID == -1)
                {
                    Console.WriteLine("\n1. Login\n2. Exit");
                    option = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (option == 1)
                    {
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        CurUserID = bank.Login(username, password);

                        if (CurUserID == -1)
                        {
                            Console.WriteLine("Invalid username or password.");
                        }
                    }
                    else if (option == 2)
                    {
                        break;
                    }

                }
                else
                {
                    Console.WriteLine($"\nWhat would you like to do {bank.GetUsersName(CurUserID)}");
                    Console.WriteLine("1. Check balance\n2. Deposit\n3. Withdraw\n4. Logout");
                    option = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine($"Your balance: {bank.GetUsersBalance(CurUserID):C}");
                            break;
                        case 2:
                            Console.Write("Deposit amount: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine());
                            bank.Deposit(CurUserID, depositAmount);
                            Console.WriteLine($"Your new balance: {bank.GetUsersBalance(CurUserID):C}");
                            break;
                        case 3:
                            Console.Write("Withdraw amount: ");
                            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                            decimal amountWithdrawn = bank.Withdraw(CurUserID, withdrawAmount);
                            Console.WriteLine($"Amount withdrawn: {amountWithdrawn:C}");
                            Console.WriteLine($"Your new balance: {bank.GetUsersBalance(CurUserID):C}");
                            break;
                        case 4:
                            Console.WriteLine($"Logging out {bank.GetUsersName(CurUserID)}...");
                            CurUserID = -1;
                            Console.WriteLine($"Bank balance after logout: {bank.BankBalance:C}");
                            break;
                    }
                }
            }
        }
    }
}