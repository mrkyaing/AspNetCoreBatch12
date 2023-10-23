namespace OOPDay2
{
    public abstract class BankOperations
    {
        public  abstract void Deposite(BankAccount bankAccount,decimal amount);
        public abstract void Withdraw(BankAccount bankAccount,decimal amount);
        public abstract void Transfer(BankAccount fromBankAccount,BankAccount toBankAccount,decimal transferAmount);
        public abstract void CheckBalance();
    }
}
