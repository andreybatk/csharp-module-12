using CSharpModule12.DAL.Interfaces;
using CSharpModule12.DAL.Exceptions;
using Newtonsoft.Json;
using CSharpModule12.DAL.Enums;

namespace CSharpModule12.DAL.Models
{
    public class BankAccount : CustomNotifyPropertyChanged, ITransaction<BankAccount>, ITopUpBankAccount<double>
    {
        private double _money;
        private int _id;
        private bool _isOpen;
        private static int _bankAccountId;

        public BankAccount(double money, AccountType accountType)
        {
            Money = money;
            Id = NextId();
            IsOpen = true;
            this.BankAccountType = accountType;
        }
        static BankAccount()
        {
            _bankAccountId = 0;
        }

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
            if (taken.Money < money)
            {
                throw new InsufficientMoneyException("Недостаточно средств!");
            }

            if (taken.BankAccountType != BankAccountType)
            {
                throw new MismatchBankAccountTypeException("Перевод возможен только между одинаковыми типами счетов!");
            }

            Money -= money;
            taken.Money += money;
        }
        public void AddMoney(double money)
        {
            ITopUpBankAccount<double> account = this;
            double balance = account.GetBalance();
            balance += money;
            Money = balance;
        }
        public double GetBalance()
        {
            return Money;
        }
        private static int NextId()
        {
            _bankAccountId++;
            return _bankAccountId;
        }
    }
}
