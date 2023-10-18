using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpModule12
{
    internal class BankAccount
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
        private static int NextId()
        {
            _bankAccountId++;
            return _bankAccountId;
        }
    }
}
