using System;
using System.Collections.Generic;
using System.Threading;

//TODO Lägga till färger i utskrifter
//TODO Gör så att olika konton har olika valuta, inklusive att valuta omvandlas när pengar flyttas mellan dem
//TODO Lägg till så att användare kan flytta pengar mellan sig
//TODO Lägg till så att saldon för alla konton för alla användare sparas mellan körningarna av programmet så att saldon inte återställs.
//TODO Menyval ändra pinkod
//TODO Kunna backa i menyvalen
namespace eBank
{
    class Program
    {
        //Creates list of User objects and adds default users to it
        static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            
            DefUsers(users);
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
                    Console.WriteLine($"\t{Welcome()}");
                    LogIn(users, out loggedIn, out userNum);
                } while (!loggedIn);
                //Logged in loop
                while(loggedIn)
                {
                    Console.Clear();
                    Console.WriteLine($"\tInloggad som {users[userNum].GetFullName()}");
                    Console.WriteLine("\n\t1. Se dina konton och saldo");
                    Console.WriteLine("\t2. Överföring mellan konton");
                    Console.WriteLine("\t3. Ta ut pengar");
                    Console.WriteLine("\t4. Sätta in pengar");
                    Console.WriteLine("\t5. Skapa nytt konto");
                    Console.WriteLine("\t6. Logga ut");
                    string input = Console.ReadLine();
                    switch(input)
                    {
                        //Print all accounts
                        case "1":
                            Console.Clear();
                            users[userNum].PrintAccounts();
                            BackToMenu();
                            break;
                        //Make transfer between internal accounts
                        case "2":
                            Console.Clear();
                            users[userNum].InternalTransfer();
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
                            users[userNum].AddAccount(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("\tNytt konto skapat!\n");
                            users[userNum].PrintAccounts();
                            BackToMenu();
                            break;
                        //Log out
                        case "6":
                            loggedIn = false;
                            break;                        
                        default:
                            Console.WriteLine("\n\tERROR! Du måste skriva en siffra mellan 1 och 4!");
                            Thread.Sleep(1000);
                            break;
                    }                        
                }               
            }          
        }
        //Method to see if accountnumber already exists
        public static bool ExistingAccountNum(int accountNum)
        {
            foreach (var user in users)
            {
                foreach (var account in user.Accounts)
                {
                    if (account.Number == accountNum)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Method for log in
        private static void LogIn(List<User> users, out bool loggedIn, out int userNum)
        {
            loggedIn = false;
            userNum = 0;
            bool correctId = false;
            //userNum to get the number of correct user-object in list.
            userNum = 0;
            do
            {
                Console.Write("\nSkriv in personnummer (12 siffror ÅÅÅÅMMDDXXXX): ");
                string id = Console.ReadLine();
                //Checks if the id is in the right format
                if (!User.ValidateId(id))
                {
                    Console.WriteLine("\n\tERROR! Personnumret är inte i korrekt format!");
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
                        Console.WriteLine("\n\tPersonnumret finns ej registrerat!");
                    }
                }
            } while (!correctId);
            Console.WriteLine("\n\tGiltligt personummer!");
            /*Get pincode input, checks format of input and compare to user-object
             * user gets 3 attempts*/
            bool correctPin = false;
            int attempts = 0;
            string input;
            int pin;
            do
            {
                Console.Write("\nSkriv in pinkod (4 siffror): ");
                input = Console.ReadLine();
                if(!Int32.TryParse(input, out pin) || input.Length != 4)
                {
                    Console.WriteLine("\n\tERROR! Du måste skriva 4st siffor!");
                    correctPin = false;
                }
                else
                {
                    if(users[userNum].Pin == pin)
                    {
                        Console.WriteLine("\n\tPinkod giltlig!");
                        correctPin = true;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine($"\n\tFel pinkod! Du har {2 - attempts} försök kvar.");
                        correctPin = false;
                        attempts++;
                    }
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
                    Console.WriteLine("Du har angett fel pinkod 3 gånger. Programmet är nu låst i 3 minuter.");
                    Console.WriteLine($"{counterMin}m {counterSec}s");
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
            string[] message = { "Välkommen!", "God dag och Välkommen!", "Kul att se dig, Välkommen!", "Redo för lite finanser? Välkommen!", "Hej och välkommen!" };
            string welcomeMsg = message[rnd.Next(0, message.Length - 1)];
            return welcomeMsg;
        }
        //Method for getting back to menu
        private static void BackToMenu()
        {
            Console.WriteLine("\n\tKlicka ENTER för att komma till huvudmenyn!");
            Console.ReadKey();
        }
        //Method for adding default users in users-list
        private static void DefUsers(List<User> users)
        {
            User user1 = new User("Robin", "Svensson", "198112189876", 6532, "Lönekonto", 59326, 30000.00);
            user1.AddAccount("Sparkonto", 64956, 451362.23);
            user1.AddAccount("Uttagskonto", 18644, 3561.20);
            User user2 = new User("Kalle", "Karlsson", "198902132458", 5617, "Sparkonto", 32493, 100000.00);
            user2.AddAccount("Uttagskonto", 72697, 2635.12);
            User user3 = new User("Petra", "Andersson", "199202296928", 1867, "Uttagskonto", 76192, 5000.50);
            user3.AddAccount("Lönekonto", 96181, 14634.35);
            User user4 = new User("Hilda", "Abrahamsson", "196212214966", 7612, "Lönekonto", 91343, 15521.52);
            user4.AddAccount("Uttagskonto", 64646, 1365.03);
            user4.AddAccount("Sparkonto", 51515, 53946.53);
            User user5 = new User("Frans", "Fransson", "200001010115", 1234, "Sparkonto", 11111, 213026.63);
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            users.Add(user5);
        }
    }
}
