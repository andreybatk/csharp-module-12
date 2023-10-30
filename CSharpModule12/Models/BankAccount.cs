using System;
using System.Collections.Generic;
using System.Windows.Documents;
using CSharpModule12.ViewModels.Base;
using CSharpModule12.ViewModels;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace CSharpModule12.Models
{
    internal class BankAccount : ViewModel, ITransaction<BankAccount>, ITopUpBankAccount<double>
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
            this.ChangesInfo = new ObservableCollection<string>();
            MainWindowViewModel.OpenOrCloseBankAccountInfo += TakeChangesInfo;
        }
        static BankAccount()
        {
            _bankAccountId = 0;
        }

        private double _money;
        private int _id;
        private bool _isOpen;
        private static int _bankAccountId;
        private ObservableCollection<string> _changesInfo;

        public double Money { get { return _money; } private set { Set(ref _money, value); } }
        public int Id { get { return _id; } private set { Set(ref _id, value); } }
        public bool IsOpen { get { return _isOpen; } private set { Set(ref _isOpen, value); } }
        [JsonProperty("AccountType")]
        public AccountType BankAccountType { get; private set; }
        public ObservableCollection<string> ChangesInfo { get { return _changesInfo; } private set { Set(ref _changesInfo, value); } }

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
        private void TakeChangesInfo(string info)
        {
            this.ChangesInfo.Add(info);
        }
        private static int NextId()
        {
            _bankAccountId++;
            return _bankAccountId;
        }
    }
}
