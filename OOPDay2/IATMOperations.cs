namespace OOPDay2
{
    public interface IATMOperations
    {
          void Withdraw(BankAccount bankAccount, decimal amount);
          void CheckBalance();
          void Topup(string phoneNumber,decimal amount);
    }
}
