using CSharpModule12.ViewModels;

namespace CSharpModule12.Models
{
    internal class Consultant : Employee
    {
        public Consultant(string firstName2, string lastName) : base(EmployeeName.Consultant, firstName2, lastName)
        {
            MainWindowViewModel.OpenOrCloseBankAccountInfo += TakeChangesInfo;
            TopUpBalanceWindowViewModel.TopUpYourBalanceInfo += TakeChangesInfo;
            TransactionWindowViewModel.TransactionInfo += TakeChangesInfo;
        }
    }
}
