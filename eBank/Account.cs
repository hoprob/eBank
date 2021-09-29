using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace eBank
{
    class Account
    {
        string name;
        int number;
        double balance;

        public Account(string name, int number, double balance)
        {
            this.name = name;
            this.number = number;
            this.balance = balance;
        }
        //Returns account information.
        public override string ToString()
        {
            return $"\tKontonummer: {this.number}" +
                $"\n\tKontonamn: {this.name}" +
                $"\n\tSaldo: {balance.ToString("C")}";
        }

    }
}
