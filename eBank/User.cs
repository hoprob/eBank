﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eBank
{
    class User
    {
        string firstName;
        string lastName;
        string id;
        int pin;
        List<Account> accounts = new List<Account>();

        public User(string firstName, string lastName, string id, int pin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.pin = pin;
        }
        public string Id
        {
            get { return this.id; }
        }
        public int Pin
        {
            get { return this.pin; }
        }
        public List<Account> Accounts
        {
            get { return this.accounts; }
        }
        //Method for deposit to account
        public void Deposit()
        {
            bool inputOk = false;
            int accountNum;
            int accountIndex = 0;
            double depositAmount;
            PrintAccounts();
            //Gets account number from user
            do
            {
                Console.Write("Välj vilket konto du vill sätta in pengar på, ange kontonummer: ");
                if(!Int32.TryParse(Console.ReadLine(), out accountNum) || accountNum.ToString().Length != 5 )
                {
                    Console.WriteLine($"\n\tERROR! Du måste skriva in kontonumret med 5st siffror!");
                    inputOk = false;
                }
                else if (!ExistingAccountNum(accountNum))
                {
                    Console.WriteLine($"\n\tERROR! Kontonumret extisterar ej!");
                    inputOk = false;
                }
                else
                {
                    accountIndex = AccountIndex(accountNum);
                    inputOk = true;
                }
            } while (!inputOk);
            //Gets amount to deposit from user
            do
            {
                Console.Write("Skriv hur mycket du vill sätta in på kontot: ");
                if(!Double.TryParse(Console.ReadLine(), out depositAmount))
                {
                    Console.WriteLine("\n\tERROR! Du måste skriva in din summa med siffor!");
                    inputOk = false;
                }
                else
                {
                    inputOk = true;
                }
            } while (!inputOk);
            //Makes deposit to account and prints info about new balance
            accounts[accountIndex].AddToBalance(depositAmount);
            Console.Clear();
            Console.WriteLine("\tInsättning genomförd! Nytt saldo:\n");
            Console.WriteLine(accounts[accountIndex].ToString());
        }
        //Method for withdrawal from account
        public void Withdrawal()
        {
            double withdrawalAmount;
            int accountNum;
            int accountIndex = 0;
            int pin;
            bool inputOk = false;
            PrintAccounts();
            //Gets user choice of account
            do
            {
                Console.Write("Välj vilket konto du vill göra uttag från, ange kontonummer: ");
                if (!Int32.TryParse(Console.ReadLine(), out accountNum) || !ExistingAccountNum(accountNum))
                {
                    Console.WriteLine($"\n\tERROR! Du måste skriva in kontonumret med 5st siffor!");
                    inputOk = false;
                }
                else if (!ExistingAccountNum(accountNum))
                {
                    Console.WriteLine($"\n\tERROR! Kontonumret extisterar ej!");
                    inputOk = false;
                }
                else
                {
                    accountIndex = AccountIndex(accountNum);
                    inputOk = true;
                }
            } while (!inputOk);
            //Gets amount of withdrawal
            do
            {
                Console.Write("Hur mycket vill du ta ut?: ");
                if (!Double.TryParse(Console.ReadLine(), out withdrawalAmount))
                {
                    Console.WriteLine($"\n\tERROR! Du måste skriva in en siffra mellan 1 och {accounts[accountIndex].Balance}");
                    inputOk = false;
                }
                else if (withdrawalAmount > accounts[accountIndex].Balance)
                {
                    Console.WriteLine($"\tDu har inte tillräckligt med pengar på kontot!\n\t Max att ta ut är: {accounts[accountIndex].Balance}");
                    inputOk = false;
                }
                else
                {
                    inputOk = true;
                }
            } while (!inputOk);
            //Gets pincode from user and verifies that it's correct
            do
            {
                Console.Write("\n\tVar god ange din pinkod: ");
                if (!Int32.TryParse(Console.ReadLine(), out pin) || pin.ToString().Length != 4)
                {
                    Console.WriteLine("\n\tERROR! Du måste skriva in 4st siffor!");
                    inputOk = false;
                }
                else if (pin == this.pin)
                {
                    inputOk = true;
                }
                else
                {
                    Console.WriteLine("\n\tPinkod ej giltlig!!");
                    inputOk = false;
                }//TODO Ska man kunna avbryta om man glömt pinkod?
            } while (!inputOk);
            //Makes withdrawal and shows new balance on the account
            accounts[accountIndex].RemoveFromBalance(withdrawalAmount);
            Console.Clear();
            Console.WriteLine("\tUttag genomfört! Nytt saldo:");
            Console.WriteLine("\n" + accounts[accountIndex].ToString());
        }
        //Method to transfer to external account
        public void ExternalTransfer(List<User> users)
        {
            int fromAccountNum;
            int fromAccountIndex = 0;
            int toAccountNum;
            int toAccountIndex = 0;
            int toUserIndex = 0;
            int pin;
            double transferSum;
            bool inputOk = false;
            PrintAccounts();
            //Gets account to transfer from
            do
            {
                Console.Write("Vilket konto vill du överföra FRÅN, ange kontonummer: ");
                if(!Int32.TryParse(Console.ReadLine(), out fromAccountNum) || fromAccountNum.ToString().Length != 5)
                {
                    Console.WriteLine($"\n\tERROR! Du måste skriva in kontonumret med 5st siffor!");
                    inputOk = false;
                }
                else if(!ExistingAccountNum(fromAccountNum))
                {
                    Console.WriteLine($"\n\tERROR! Kontonumret extisterar ej!");
                    inputOk = false;
                }
                else
                {
                    fromAccountIndex = AccountIndex(fromAccountNum);
                    inputOk = true;
                }
            } while(!inputOk);
            //Gets account to transfer to
            do
            {
                Console.Write("Vilket konto vill du överföra TILL, ange kontonummer: ");
                if (!Int32.TryParse(Console.ReadLine(), out toAccountNum) || toAccountNum.ToString().Length != 5)
                {
                    Console.WriteLine($"\n\tERROR! Du måste skriva in kontonumret med 5st siffor!");
                    inputOk = false;
                }
                else if (!ExistingAccountNum(toAccountNum, users))
                {
                    Console.WriteLine($"\n\tERROR! Kontonumret extisterar ej!");
                    inputOk = false;
                }
                else
                {
                    bool answerOk = false;
                    string input;
                    //Gets index of user and account 
                    UserAccountIndex(toAccountNum, users, out toUserIndex, out toAccountIndex);
                    //Checks that the account holder is correct
                    Console.WriteLine($"Kontot {toAccountNum} tillhör: {users[toUserIndex].GetFullName()}");
                    do
                    {
                        Console.Write("För att godkänna mottagare skriv [Y] för JA eller [N] för NEJ: ");
                        input = Console.ReadLine().ToUpper();
                        if (input == "Y")
                        {
                            inputOk = true;
                            answerOk = true;
                        }
                        else if (input == "N")
                        {
                            inputOk = false;
                            answerOk = true;
                        }
                        else
                        {
                            Console.WriteLine("\n\tERROR! Du måste svara med [Y] för JA eller [N] för NEJ!");
                            answerOk = false;
                        }
                    } while (!answerOk);  
                }
            } while (!inputOk);
            //Gets the transfer sum
            do
            {
                Console.Write("Hur mycket vill du föra över?: ");
                if(!Double.TryParse(Console.ReadLine(), out transferSum))
                {
                    Console.WriteLine($"\n\tERROR! Du måste ange en siffra mellan 1 och {accounts[fromAccountIndex].Balance}");
                    inputOk = false;
                }
                else if (transferSum > accounts[fromAccountIndex].Balance)
                {
                    Console.WriteLine($"\tDu har inte tillräckligt med pengar på kontot!\n\t Max att föra över är: {accounts[fromAccountIndex].Balance}");
                    inputOk = false;
                }
                else
                {
                    inputOk = true;
                }
            } while (!inputOk);
            //Asks user to confirm with pincode
            do
            {
                Console.Write("\n\tVar god ange din pinkod: ");
                if (!Int32.TryParse(Console.ReadLine(), out pin) || pin.ToString().Length != 4)
                {
                    Console.WriteLine("\n\tERROR! Du måste skriva in 4st siffor!");
                    inputOk = false;
                }
                else if (pin == this.pin)
                {
                    inputOk = true;
                }
                else
                {
                    Console.WriteLine("\n\tPinkod ej giltlig!!");
                    inputOk = false;
                }//TODO Ska man kunna avbryta om man glömt pinkod?
            } while (!inputOk);//TODO Ändra bool till pinOk?
            //Makes tranfer between accounts
            accounts[fromAccountIndex].RemoveFromBalance(transferSum);
            users[toUserIndex].accounts[toAccountIndex].AddToBalance(transferSum);
            Console.Clear();
            //Prints new balance on logged in users account
            Console.WriteLine("\tTransaktion godkänd!");
            Console.WriteLine("\tDitt nya saldo är: \n");
            Console.WriteLine(accounts[fromAccountIndex].ToString());
        }
        //Method to transfer money between users internal accounts
        public void InternalTransfer()
        {
            int fromAccountNum;
            int fromAccountIndex = 0;
            int toAccountNum;
            int toAccountIndex = 0;
            double transferSum;
            bool inputOk = false;
            PrintAccounts();
            //Gets accountnumber to transfer from
            do
            {
                Console.Write("Vilket konto vill du överföra FRÅN, ange kontonummer: ");
                if (!Int32.TryParse(Console.ReadLine(), out fromAccountNum) || fromAccountNum.ToString().Length != 5)
                {
                    Console.WriteLine($"\n\tERROR! Du måste ange kontonumret med 5st siffror!");
                    inputOk = false;
                }
                else if(!ExistingAccountNum(fromAccountNum))
                {
                    Console.WriteLine($"\n\tERROR! Kontonumret extisterar ej!");
                    inputOk = false;
                }
                else
                {
                    fromAccountIndex = AccountIndex(fromAccountNum);
                    inputOk = true;
                }
            } while (!inputOk);
            //Gets account number to transfer to
            do
            {
                Console.Write("Vilket konto vill du överföra TILL, ange kontonummer: ");
                if (!Int32.TryParse(Console.ReadLine(), out toAccountNum) || toAccountNum.ToString().Length != 5)
                {
                    Console.WriteLine($"\n\tERROR! Du måste ange kontonumret med 5st siffror!");
                    inputOk = false;
                }
                else if (!ExistingAccountNum(toAccountNum))
                {
                    Console.WriteLine($"\n\tERROR! Kontonumret extisterar ej!");
                    inputOk = false;
                }
                else
                {
                    toAccountIndex = AccountIndex(toAccountNum);
                    inputOk = true;
                }
            } while (!inputOk);
            //Gets sum to transfer and checks that there is enough money on from account
            do
            {
                Console.Write("\nHur mycket vill du föra över?: ");
                if (!Double.TryParse(Console.ReadLine(), out transferSum))
                {
                    Console.WriteLine($"\n\tERROR! Du måste ange en siffra mellan 1 och {accounts[fromAccountIndex].Balance}");
                    inputOk = false;
                }
                else if(transferSum > accounts[fromAccountIndex].Balance)
                {
                    Console.WriteLine($"\tDu har inte tillräckligt med pengar på kontot!\n\t Max att föra över är: {accounts[fromAccountIndex].Balance}");
                    inputOk = false;
                }
                else
                {
                    inputOk = true;
                }
            } while (!inputOk);
            //Adds transfer sum to toAccount and takes the same from fromAccount
            accounts[toAccountIndex].AddToBalance(transferSum); 
            accounts[fromAccountIndex].RemoveFromBalance(transferSum);
            //Prints the new balance of the two accounts
            Console.Clear();
            Console.WriteLine("\tNya saldon är:\n");
            Console.WriteLine(accounts[fromAccountIndex].ToString() + "\n");
            Console.WriteLine(accounts[toAccountIndex].ToString());
        }
        public void UserAccountIndex(int accountNum, List<User> users, out int userIndex, out int accountIndex)
        {
            userIndex = 0;
            accountIndex = 0;
            bool searchBool = true;
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < users[i].accounts.Count; j++)
                {
                    if (accountNum == users[i].accounts[j].Number)
                    {
                        userIndex = i;
                        accountIndex = j;
                        searchBool = false;
                        break;
                    }                 
                }
                if (!searchBool)
                    break;
            }
        }
        public int AccountIndex(int accountNum)
        {
            int accountIndex = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accountNum == accounts[i].Number)
                {
                    accountIndex = i;
                    break;
                }
            }
            return accountIndex;
        }
        public bool ExistingAccountNum(int accountNum, List<User> users)
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
        public bool ExistingAccountNum(int accountNum)
        {
            foreach (var account in accounts)
            {
                if(accountNum == account.Number)
                {
                    return true;
                }
            }
            return false;
        }
        //Method to print information about all users accounts
        public void PrintAccounts()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine(account.ToString());
                Console.WriteLine();
            }
        }
        //Method to add an account with random accountnumber of 5 integers
        public void AddAccount(Account newAccount/*string accountName, int accountNum = 0, double balance = 0*/)
        {
            accounts.Add(newAccount);
            //Random rnd = new Random();
            //do
            //{
            //    if(accountNum < 10000)
            //    {
            //        accountNum = rnd.Next(10000, 99999);
            //    }                       
            //} while (Program.ExistingAccountNum(accountNum)); //TODO Finns det en bättre lösning på detta??
            //Account newAccount = new Account(accountName, accountNum, balance);
            //this.accounts.Add(newAccount);
        }

        //Method to get users full name
        public string GetFullName()
        {
            return this.firstName + " " + this.lastName;
        }
        //Method to validate a Swedish social security number
        public static bool ValidateId(string id)
        {
            bool correctId = false;
            try
            {
                if (id.Length == 12)
                {
                    //Seperates parts of id number
                    int year = Int32.Parse(id.Substring(0, 4));
                    int month = Int32.Parse(id.Substring(4, 2));
                    int day = Int32.Parse(id.Substring(6, 2));
                    //Controlnumber is the last digit in id number
                    int controlNum = Int32.Parse(id.Substring(11, 1));
                    //Changes the string to an array with the seperat digits
                    string controlString = id.Substring(2, 9);
                    int[] controlArray = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        controlArray[i] = Int32.Parse(controlString.Substring(i, 1));
                    }
                    //The process to get the control sum to check Controlnumber
                    int controlSum= 0;
                    int addNum;
                    for (int i = 0; i < 9; i++)
                    {
                        //First digit will multiply by 2, second 1, third 2 and so on.
                        if (i % 2 == 0)
                        {
                            addNum = controlArray[i] * 2;
                        }
                        else
                        {
                            addNum = controlArray[i] * 1;
                        }
                        //If the product is two digits, you must add them up before add to controlSum
                        if (addNum > 9)
                        {
                            string numString = addNum.ToString();
                            int num1 = Int32.Parse(numString.Substring(0, 1));
                            int num2 = Int32.Parse(numString.Substring(1, 1));
                            controlSum += num1 + num2;
                        }
                        //If the product is 1 digit, it ads up to the controlSum
                        else
                        {
                            controlSum += addNum;
                        }
                    }
                    //Rounds to upper 10.
                    int upperControlNum = (controlSum / 10 + 1) * 10;
                    //The control number must be the same as the controlsum rounded to upper 10 minus the controlsum.
                    if(controlNum == upperControlNum - controlSum)
                    {
                        //Checks that month and day is correct and that it acctually existed
                        if (month >= 1 && month <= 12 && day > 0)
                        {
                            if (month % 2 != 0 || month == 8 && day <= 31)
                            {
                                correctId = true;
                            }            
                            else if (month % 2 == 0 && day <= 30)
                            {
                                correctId = true;
                                bool leapYear = LeapYear(year);
                                if (!leapYear && month == 02 && day > 28)
                                {
                                    correctId = false;
                                }
                                else if (leapYear && month == 2 && day > 29)
                                {
                                    correctId = false;
                                }   
                            }
                        }
                    }                                      
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\tERROR! Du måste skriva personnummer med siffor!");
            }
            return correctId;
        }
        //Method to calculate if it's leapyear or not
        public static bool LeapYear(int year)
        {
            bool isLeepYear = false;
            try
            {
                double yearDbl = Convert.ToDouble(year);
                if (yearDbl % 4 == 0)
                {
                    isLeepYear = true;
                    if (yearDbl % 100 == 0)
                    {
                        isLeepYear = false;
                        if (yearDbl % 400 == 0)
                        {
                            isLeepYear = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isLeepYear;
        }
    }
}
