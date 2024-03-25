namespace CSharpModule12.DAL.Interfaces
{
    public interface ITopUpBankAccount<out T>
    {
        T GetBalance();
    }
}