namespace CSharpModule12.Models
{
    internal interface ITransaction<in T>
    {
        void MoneyTransfer(T taken, double money);
    }
}
