namespace CSharpModule12.Models
{
    internal interface ITopUpBankAccount<out T>
    {
        T GetBalance();
    }
}
