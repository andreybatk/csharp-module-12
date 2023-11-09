namespace CSharpModule12.Infrastructure
{
    internal interface ITransaction<in T>
    {
        void MoneyTransfer(T taken, double money);
    }
}
