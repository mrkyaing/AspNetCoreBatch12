using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDay2
{
    partial class LoanOperationService : ILoanOperations
    {
        private readonly BankAccount _bankAccount;
        //constructor injection for  BankAccount class 
        public LoanOperationService(BankAccount bankAccount)
        {
          _bankAccount = bankAccount;
        }
        public void HomeLoan(decimal loanAmount, DateTime loanedDate)
        {
            Console.WriteLine("Home lone is successfully");
            Console.WriteLine("You loan at " + loanedDate);
        }

        public void LoanInstallment(decimal installmentAmount, string loanType)
        {
            if (loanType.Equals("homeloan"))
            {
                Console.WriteLine("Home lone installment is paid with amount "+installmentAmount);
                _bankAccount.OpeningBalance -= installmentAmount;
            }
            if (loanType.Equals("smeloan"))
            {
                Console.WriteLine("Home lone installment is paid with amount " + installmentAmount);
                _bankAccount.OpeningBalance -= installmentAmount;
            }
            if (loanType.Equals("vehicleloan"))
            {
                Console.WriteLine("Home lone installment is paid with amount " + installmentAmount);
                _bankAccount.OpeningBalance -= installmentAmount;
            }
        }

        public void SMELoand(string copanyLicneceNo, decimal loanAmount, DateTime loanedDate)
        {
            if (!string.IsNullOrEmpty(copanyLicneceNo))
            {
                Console.WriteLine("SMELoand is successfully for this company licnece "+copanyLicneceNo);
                Console.WriteLine("You loan at " + loanedDate);
            }
        }
        public void VehicleLoan(decimal loanAmount, DateTime loanedDate)
        {
            Console.WriteLine("Vehicle lone is successfully");
            Console.WriteLine("You loan at " + loanedDate);
        }
    }
}
