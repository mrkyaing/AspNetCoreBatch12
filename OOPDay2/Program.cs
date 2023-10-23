using OOPDay2;

Console.WriteLine("Welcome to Banking System");
Customer c1 = new Customer()
{
    Name = "Mg Mg", Nrc = "12/DAKANA(N)1234566", PhoneNumber = "09123456",Address="YGN-Hlaing"
};
BankAccount bankAccount1 = new BankAccount()
{
    AccountName="U"+c1.Name, AccountNumer="00112233445566",OpeningBalance=500000
};
c1.BankAccount = bankAccount1;
bankAccount1.CheckBalance();//500000
c1.ShowInfo();
Customer c2 = new Customer()
{
    Name = "Su Su",
    Nrc = "12/DAKANA(N)654321",
    PhoneNumber = "09123456",
    Address = "YGN-Mayangone",
    BankAccount=new BankAccount()
    {
        AccountName = "Daw SU SU",
        AccountNumer = "000111222333",
        OpeningBalance = 100000
    }
};
c2.BankAccount.CheckBalance();//100000
c2.BankAccount.Deposite(c2.BankAccount,100000);
c2.BankAccount.CheckBalance();//200000
bankAccount1.Transfer(bankAccount1, c2.BankAccount, 400000);
bankAccount1.CheckBalance();//100000
c2.BankAccount.CheckBalance();//600000
c2.BankAccount.Topup("09256275319", 100000);
c2.BankAccount.CheckBalance();//500000
ILoanOperations loanOperations = new LoanOperationService(c2.BankAccount);
loanOperations.HomeLoan(100000, DateTime.Now);
loanOperations.LoanInstallment(100000, "homeloan");
c2.BankAccount.CheckBalance();//400000

