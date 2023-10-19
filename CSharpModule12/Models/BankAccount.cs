using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpModule12.Models
{
    internal class BankAccount : ITransaction<BankAccount>
    {
        public BankAccount(double money)
        {
            this.Money = money;
            this.Id = NextId();
            this.IsOpen = true;
        }
        static BankAccount()
        {
            _bankAccountId = 0;
        }
        public double Money { get; private set; }
        public int Id { get; private set; }
        public bool IsOpen { get; private set; }
        private static int _bankAccountId;

        /// <summary>
        /// Открытие/Закрытие счета
        /// </summary>
        /// <param name="isOpen">True - статус открытый; False - статус закрытый;</param>
        public void OpenOrCloseBankAccount(bool isOpen)
        {
            this.IsOpen = isOpen;
        }
        public void MoneyTransfer(BankAccount taken, double money)
        {
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
