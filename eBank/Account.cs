using System.IO;
//Robin Svensson SUT-21
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
        public int Number
        {
            get { return this.number; }
        }
        //Method to add an amount to balance
        public void AddToBalance(double amount)
        {
            this.balance += amount;
        }
        //Method to remove an amoount from balance
        public void RemoveFromBalance(double amount)
        {
            this.balance -= amount;
        }
        //Method to print balance
        public string PrintBalance()
        {
            return this.balance.ToString("C");
        }
        //Method to check if transferSum is bigger than balance
        public bool EnoughBalance(double transferSum)
        {
            if (transferSum > this.balance)
                return false;
            else
                return true;
        }
        //Method to print account to .txt file
        public void PrintToFile(StreamWriter sw)
        {
            sw.WriteLine( $"{this.name}@@@{this.number}@@@{this.balance}");
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
