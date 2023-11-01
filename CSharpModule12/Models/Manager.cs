using CSharpModule12.ViewModels;

namespace CSharpModule12.Models
{
    internal class Manager : Employee
    {
        public Manager(string firstName, string lastName) : base(EmployeeName.Manager, firstName, lastName)
        {
            MainWindowViewModel.OpenOrCloseBankAccountInfo += TakeChangesInfo;
            TopUpBalanceWindowViewModel.TopUpYourBalanceInfo += TakeChangesInfo;
            TransactionWindowViewModel.TransactionInfo += TakeChangesInfo;
        }
    }
}
