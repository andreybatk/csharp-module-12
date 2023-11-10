using System.Collections.ObjectModel;
using static CSharpModule12.DAL.Models.BankAccount;

namespace CSharpModule12.DAL.Models
{
    public class Client : CustomNotifyPropertyChanged
    {
        public Client(string firstName, string lastName)
        {
            this.Id = NextId();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ClientBankAccounts = new ObservableCollection<BankAccount>();
        }
        static Client()
        {
            _clientId = 0;
        }
       
        private static int _clientId;
        private int _id;
        private string _firstName;
        private string _lastName;

        public int Id { get => _id; private set => Set(ref _id, value); }
        public string FirstName { get => _firstName; private set => Set(ref _firstName, value); }
        public string LastName { get => _lastName; private set => Set(ref _lastName, value); }
        public ObservableCollection<BankAccount> ClientBankAccounts { get; private set; }

        public void CreateBankAccounts(double money)
        {
            ClientBankAccounts.Add(new BankAccount(money, AccountType.Deposit));
            ClientBankAccounts.Add(new BankAccount(money, AccountType.NonDeposit));
        }
        private static int NextId()
        {
            _clientId++;
            return _clientId;
        }
    }
}
