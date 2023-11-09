namespace CSharpModule12.Infrastructure
{
    internal interface ITopUpBankAccount<out T>
    {
        T GetBalance();
    }
}
