using CSharpModule12.ViewModels;

namespace CSharpModule12.Models
{
    internal class Consultant : Employee
    {
        public Consultant(EmployeeName jobTitle,string firstName, string lastName) : base(jobTitle, firstName, lastName)
        {
            MainWindowViewModel.OpenOrCloseBankAccountInfo += TakeChangesInfo;
            TopUpBalanceWindowViewModel.TopUpYourBalanceInfo += TakeChangesInfo;
            TransactionWindowViewModel.TransactionInfo += TakeChangesInfo;
        }
    }
}
