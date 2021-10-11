using System;
using System.Collections.Generic;
using System.Threading;

//TODO Lägga till färger i utskrifter
//TODO Ska metoderna för färgutskrift ligga i program klassen? Hur ska man nå dem från user klassen ?
//TODO Snygga till utskrifter
//TODO Gör så att olika konton har olika valuta, inklusive att valuta omvandlas när pengar flyttas mellan dem
//TODO Lägg till så att saldon för alla konton för alla användare sparas mellan körningarna av programmet så att saldon inte återställs.
//TODO Menyval ändra pinkod
//TODO Kunna backa i menyvalen
//TODO Sortera kontonumren i utskriften
//TODO Historik i överföring

namespace eBank
{
    class Program
    {
        //Creates list of User objects and adds default users to it
        static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            
            DefUsers();
            bool isRunning = true;
            int userNum;
            bool loggedIn;
            //Main loop
            while(isRunning)
            {
                userNum = 0;//TODO Skall nollning av användare ligga här?
                loggedIn = false;
                do
                {
                    Console.Clear();
                    PrintGreeting($"\t{Welcome()}");
                    LogIn(users, out loggedIn, out userNum);
                } while (!loggedIn);
                //Logged in loop
                while(loggedIn)
                {
                    Console.Clear();
                    PrintGreeting($"\tInloggad som" +
                        $" {users[userNum].GetFullName()}");
                    PrintMenuNum("\n\t1.");
                    Console.WriteLine(" Se dina konton och saldo");
                    PrintMenuNum("\t2.");
                    Console.WriteLine(" Överföring mellan konton");
                    PrintMenuNum("\t3.");
                    Console.WriteLine(" Ta ut pengar");
                    PrintMenuNum("\t4.");
                    Console.WriteLine(" Sätta in pengar");
                    PrintMenuNum("\t5.");
                    Console.WriteLine(" Skapa nytt konto");
                    PrintMenuNum("\t6.");
                    Console.WriteLine(" Logga ut");
                    string input = Console.ReadLine();
                    switch(input)
                    {
                        //Print all accounts
                        case "1":
                            Console.Clear();
                            users[userNum].PrintAccounts();
                            BackToMenu();
                            break;
                        //Make transfer between internal or external accounts
                        case "2":
                            Console.Clear();
                            TransferMenu(userNum);
                            BackToMenu();
                            break;
                        //Make withdrawal
                        case "3":
                            Console.Clear();
                            users[userNum].Withdrawal();
                            BackToMenu();
                            break;
                        //Make deposit
                        case "4":
                            Console.Clear();
                            users[userNum].Deposit();
                            BackToMenu();
                            break;
                        //Create new account
                        case "5":
                            Console.Clear();
                            Console.Write("\tSkriv in namn på kontot: ");
                            //string accountName = Console.ReadLine();
                            AddAccount(userNum, Console.ReadLine());
                            Console.Clear();
                            PrintSuccess("\tNytt konto skapat!\n");
                            users[userNum].PrintAccounts();
                            BackToMenu();
                            break;
                        //Log out
                        case "6":
                            loggedIn = false;
                            break;                        
                        default:
                            Console.WriteLine("\n\tERROR! Du måste skriva en" +
                                " siffra mellan 1 och 6!");
                            Thread.Sleep(1000);
                            break;
                    }                        
                }               
            }          
        }
        //Method for log in
        private static void LogIn(List<User> users, out bool loggedIn,
            out int userNum)
        {
            loggedIn = false;
            userNum = 0;
            bool correctId = false;
            //userNum to get the number of correct user-object in list.
            userNum = 0;
            do
            {
                Console.Write("\nSkriv in personnummer (");
                PrintInfo("12 siffror ÅÅÅÅMMDDXXXX");
                Console.Write("): ");
                string id = Console.ReadLine();
                //Checks if the id is in the right format
                if (!User.ValidateId(id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintDanger("\n\tERROR! Personnumret är inte i korrekt" +
                        " format!");
                    correctId = false;
                }
                else
                {
                    //Searching for id in list of users
                    for (int i = 0; i < users.Count; i++)
                    {
                        if(users[i].Id == id)
                        {
                            correctId = true;
                            userNum = i;
                        }
                    }
                    if(!correctId)
                    {
                        PrintWarning("\n\tPersonnumret finns ej registrerat!");
                    }
                }
            } while (!correctId);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\tGiltligt personummer!");
            Console.ResetColor();
            /*Get pincode input, checks format of input and compare to user-object
             * user gets 3 attempts*/
            bool correctPin = false;
            int attempts = 0;
            do
            {
                if(users[userNum].CheckPin(users[userNum].GetPin()))
                {
                    PrintSuccess("\n\tPinkod giltlig!");
                    correctPin = true;
                    Thread.Sleep(1000);
                }
                else
                {
                    PrintDanger($"\n\tFel pinkod! Du har {2 - attempts}" +
                        $" försök kvar.");
                    correctPin = false;
                    attempts++;
                }               
            } while (!correctPin && attempts < 3);
            //Locks program for 3 min. With printed countdown.
            if (!correctPin)
            {               
                int counterMin = 2;
                int counterSec = 59;
                for (int i = 0; i <= 180; i++)
                {
                    Console.Clear();
                    PrintDanger("Du har angett fel pinkod 3 gånger." +
                        " Programmet är nu låst i 3 minuter.");
                    PrintDanger($"{counterMin}m {counterSec}s");
                    if(counterSec == 0 && counterMin > 0)
                    {
                        counterSec = 59;
                        counterMin--;
                    }
                    else
                    {
                        counterSec--;
                    }
                    Thread.Sleep(1000);
                }
            }
            //Checks that both id and pin is correct.
            if(correctId && correctPin)
            {
                loggedIn = true;
            }
            else
            {
                loggedIn = false;
            }           
        }
        //Method for a random welcome-message
        private static string Welcome()
        {
            Random rnd = new Random();
            string[] message = { "Välkommen!", "God dag och Välkommen!",
                "Kul att se dig, Välkommen!", "Redo för lite finanser? Välkommen!",
                "Hej och välkommen!" };
            string welcomeMsg = message[rnd.Next(0, message.Length - 1)];
            return welcomeMsg;
        }
        //Method to add new account to a user
        private static void AddAccount(int userNum, string accountName,
            int accountNum = 0, double balance = 0)
        {
            Random rnd = new Random();
            bool existingAccount = false;
            do
            {
                existingAccount = users[userNum].ExistingAccountNum(accountNum,
                    users);
                if (existingAccount || accountNum < 10000 || accountNum > 99999)
                {
                    accountNum = rnd.Next(10000, 99999);
                }
            } while (existingAccount);
            Account newAccount = new Account(accountName, accountNum, balance);
            users[userNum].AddAccount(newAccount);
        }
        //Method for Transfer menu
        private static void TransferMenu(int userNum)
        {
            bool transferBool = true; ;
            while(transferBool)
            {
                Console.Clear();
                Console.WriteLine("\tVilken typ av överföring vill du göra?");
                PrintMenuNum("\n\t1.");
                Console.WriteLine(" Till ett eget konto");
                PrintMenuNum("\t2.");
                Console.WriteLine(" Till ett externt konto");
                PrintMenuNum("\n\t3.");
                Console.WriteLine(" Avbryt");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        users[userNum].InternalTransfer();
                        transferBool = false;
                        break;
                    case "2":
                        Console.Clear();
                        users[userNum].ExternalTransfer(users);
                        transferBool = false;
                        break;
                    case "3":
                        transferBool = false;
                        break;
                    default:
                        PrintDanger("\n\tERROR! Du måste skriva en siffra" +
                            " mellan 1 och 3");
                        transferBool = true;
                        Thread.Sleep(1000);
                        break;
                }
            }          
        }
        //Method for getting back to menu
        private static void BackToMenu()
        {
            PrintInfo("\n\tKlicka ENTER för att komma till huvudmenyn!");
            Console.ReadKey();
        }
        //Method to print menu numbers in the color theme
        private static void PrintMenuNum(string num)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(num);
            Console.ResetColor();
        }
        //Method to print greetings in the color theme
        private static void PrintGreeting(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        //Method to print info texts in the color theme
        private static void PrintInfo(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(text);
            Console.ResetColor();
        }
        //Method to print Danger/Error texts in the color theme
        private static void PrintDanger(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        //Method to print warnings in the color theme
        private static void PrintWarning(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        //Method to print success texts in the color theme
        private static void PrintSuccess(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        //Method for adding default users in users-list
        private static void DefUsers()
        {
            User user1 = new User("Robin", "Svensson", "198112189876", 6532);
            users.Add(user1);
            AddAccount(0, "Lönekonto", 59326, 30000.00);
            AddAccount(0, "Sparkonto", 64956, 451362.23);
            AddAccount(0, "Uttagskonto", 18644, 3561.20);
            User user2 = new User("Kalle", "Karlsson", "198902132458", 5617);
            users.Add(user2);
            AddAccount(1, "Sparkonto", 32493, 100000.00);
            AddAccount(1, "Uttagskonto", 72697, 2635.12);
            User user3 = new User("Petra", "Andersson", "199202296928", 1867);
            users.Add(user3);
            AddAccount(2, "Uttagskonto", 76192, 5000.50);
            AddAccount(2, "Lönekonto", 96181, 14634.35);
            User user4 = new User("Hilda", "Abrahamsson", "196212214966", 7612);
            users.Add(user4);
            AddAccount(3, "Lönekonto", 91343, 15521.52);
            AddAccount(3, "Uttagskonto", 64646, 1365.03);
            AddAccount(3, "Sparkonto", 51515, 53946.53);
            User user5 = new User("Frans", "Fransson", "200001010115", 1234);
            users.Add(user5);
            AddAccount(4, "Sparkonto", 11111, 213026.63);    
        }
    }
}
