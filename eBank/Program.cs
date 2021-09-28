using System;
using System.Collections.Generic;
using System.Threading;

namespace eBank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            DefUsers(users);
            Console.WriteLine($"\t{Welcome()}");
            LogIn(users);
        }
        //Method for log in
        private static bool LogIn(List<User> users)
        {
            bool loggedIn = false;
            bool correctId = false;
            //userNum to get the number of correct user-object in list.
            int userNum = 0;
            do
            {
                Console.Write("\nSkriv in personnummer (12 siffror ÅÅÅÅMMDDXXXX): ");
                string id = Console.ReadLine();
                //Checks if the id is in the right format
                if (!User.ValidateId(id))
                {
                    Console.WriteLine("\n\tERROR! Personnummret är inte i korrekt format!");
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
            return loggedIn;
        }
        //Method for a random welcome-message
        private static string Welcome()
        {
            Random rnd = new Random();
            string[] message = { "Välkommen!", "God dag och Välkommen!", "Kul att se dig, Välkommen!", "Redo för lite finanser? Välkommen!", "Hej och välkommen!" };
            string welcomeMsg = message[rnd.Next(0, message.Length - 1)];
            return welcomeMsg;
        }
        //Method for adding default users in users-list
        private static void DefUsers(List<User> users)
        {
            User user1 = new User("Robin", "Svensson", "198112189876", 6532);
            User user2 = new User("Kalle", "Karlsson", "198902132458", 5617);
            User user3 = new User("Petra", "Andersson", "199202296928", 1867);
            User user4 = new User("Hilda", "Abrahamsson", "196212214966", 7612);
            User user5 = new User("Frans", "Fransson", "200001010115", 1234);
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            users.Add(user5);
        }
    }
}
