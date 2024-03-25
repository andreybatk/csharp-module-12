namespace CSharpModule12.DAL.Interfaces
{
    public interface ITransaction<in T>
    {
        void MoneyTransfer(T taken, double money);
    }
}