using System;
using System.Security.Cryptography.X509Certificates;

namespace OOPDay2
{
    public class BankAccount : BankOperations,IATMOperations
    {
        public string AccountNumer { get; set; }
        public string AccountName { get; set; }
        public decimal OpeningBalance { get; set; }
        public void ShowInfo()
        {
            Console.WriteLine("Bank Account information ");
            Console.WriteLine("AccountNumer:" + AccountNumer);
            Console.WriteLine("AccountName" + AccountName);
            Console.WriteLine("OpeningBalance:" + OpeningBalance);
        }
        public override void Transfer(BankAccount fromBankAccount, BankAccount toBankAccount, decimal transferAmount)
        {
            CheckValidAmount(transferAmount);

            if (transferAmount > fromBankAccount.OpeningBalance)
                Console.WriteLine("you cannot enough money to transfer" + "Current Amount is " + fromBankAccount.OpeningBalance);
            else
            {
                toBankAccount.OpeningBalance += transferAmount;
                fromBankAccount.OpeningBalance -= transferAmount;
                Console.WriteLine("Transfer successfully");
            }
        }
        public override void Withdraw(BankAccount bankAccount, decimal amount)
        {
            CheckValidAmount(amount);
            if (amount > bankAccount.OpeningBalance)
                Console.WriteLine("you cannot enough money." + "Current Amount is " + bankAccount.OpeningBalance);
            else
            {
                bankAccount.OpeningBalance -= amount;
                Console.WriteLine("Withdraw successfully");
                Console.WriteLine("Current Amount is " + bankAccount.OpeningBalance);
            }
        }
        public override void Deposite(BankAccount bankAccount, decimal amount)
        {
            CheckValidAmount(amount);
            if (bankAccount.AccountNumer.Equals(this.AccountNumer))
            {
                this.OpeningBalance += amount;
                Console.WriteLine("Deposite successfully");
            }
        }

        private void CheckValidAmount(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("invalid amount ");
        }

        public override void CheckBalance()=>Console.WriteLine("Current balance is " + this.OpeningBalance);

        public void Topup(string phoneNumber, decimal amount)
        {
            if (amount > this.OpeningBalance)
            {
                Console.WriteLine("you cannot enough money");
            }       
        else   if(!string.IsNullOrEmpty(phoneNumber))
            {
                Console.WriteLine($"{phoneNumber} is topuped successfully with {amount} kyats");
                this.OpeningBalance -= amount;
            }
        } 
    }
}
