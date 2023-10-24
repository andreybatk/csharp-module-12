using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CSharpModule12.ViewModels.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CSharpModule12.Models
{
    internal class BankAccount : ViewModel, ITransaction<BankAccount>
    {
        public enum AccountType
        {
            Deposit = 0,
            NonDeposit
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
        public AccountType BankAccountType { get; set; }

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
            if(this.BankAccountType != taken.BankAccountType)
            {
                MessageBox.Show("Перевод возможен только между одинаковыми типами счетов!", "Ошибка");
                return;
            }
            if(this.Money <= money)
            {
                MessageBox.Show("Недостаточно средств!", "Ошибка");
                return;
            }
            this.Money -= money;
            taken.Money += money;
        }
        public void AddMoney(double money)
        {
            this.Money += money;
        }
        private static int NextId()
        {
            _bankAccountId++;
            return _bankAccountId;
        }
    }
}
