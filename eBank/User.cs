using System;
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

        public User(string firstName, string lastName, string id, int pin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.pin = pin;
        }
        public User()
        {

        }
        public string Id
        {
            get { return this.id; }
        }
        public int Pin
        {
            get { return this.pin; }
        }
        public string GetFullName()
        {
            return this.firstName + " " + this.lastName;
        }
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
                        //Checks that month and day is correct.
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
