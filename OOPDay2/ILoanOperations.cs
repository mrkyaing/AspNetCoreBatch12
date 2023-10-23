using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDay2
{
    public interface ILoanOperations
    {
        void HomeLoan(decimal loanAmount, DateTime loanedDate);
        void SMELoand(string copanyLicneceNo,decimal loanAmount, DateTime loanedDate);
        void VehicleLoan(decimal loanAmount, DateTime loanedDate);
        void LoanInstallment(decimal installmentAmount, string loanType);
    }
}
