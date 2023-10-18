using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpModule12
{
    internal class Client
    {
        public Client(string firstName, string lastName)
        {
            this.Id = NextId();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ClientBankAccount = new List<BankAccount>();
        }
        static Client()
        {
            _clientId = 0;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<BankAccount> ClientBankAccount { get; private set; }
        private static int _clientId;

        public void CreateBankAccount(double money)
        {
            ClientBankAccount.Add(new BankAccount(money));
        }
        private static int NextId()
        {
            _clientId++;
            return _clientId;
        }
    }
}
