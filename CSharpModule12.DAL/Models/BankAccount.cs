using CSharpModule12.DAL.Interfaces;
using CSharpModule12.DAL.Exceptions;
using Newtonsoft.Json;

namespace CSharpModule12.DAL.Models
{
    public class BankAccount : CustomNotifyPropertyChanged, ITransaction<BankAccount>, ITopUpBankAccount<double>
    {
        public enum AccountType
        {
            Deposit = 0,
            NonDeposit = 1
        }
        public BankAccount(double money, AccountType accountType)
        {
            this.Money = money;
            this.Id = NextId();
            this.IsOpen = true;
            this.BankAccountType = accountType;
        }
        static BankAccount()
        {
            _bankAccountId = 0;
        }

        private double _money;
        private int _id;
        private bool _isOpen;
        private static int _bankAccountId;

        public double Money { get { return _money; } private set { Set(ref _money, value); } }
        public int Id { get { return _id; } private set { Set(ref _id, value); } }
        public bool IsOpen { get { return _isOpen; } private set { Set(ref _isOpen, value); } }
        [JsonProperty("AccountType")]
        public AccountType BankAccountType { get; private set; }

        /// <summary>
        /// Открытие/Закрытие счета
        /// </summary>
        /// <param name="isOpen">True - статус открытый; False - статус закрытый;</param>
        public void OpenOrCloseBankAccount()
        {
            IsOpen = !IsOpen;
        }
        public void MoneyTransfer(BankAccount taken, double money)
        {
            if(taken.Money < money)
            {
                throw new InsufficientMoneyException("Недостаточно средств!");
            }

            if(taken.BankAccountType != this.BankAccountType)
            {
                throw new MismatchBankAccountTypeException("Перевод возможен только между одинаковыми типами счетов!");
            }

            this.Money -= money;
            taken.Money += money;
        }
        public void AddMoney(double money)
        {
            ITopUpBankAccount<double> account = this;
            double balance = account.GetBalance();
            balance += money;
            this.Money = balance;
        }
        public double GetBalance()
        {
            return this.Money;
        }
        private static int NextId()
        {
            _bankAccountId++;
            return _bankAccountId;
        }
    }
}
