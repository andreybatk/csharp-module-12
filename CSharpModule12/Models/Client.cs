using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpModule12.ViewModels.Base;

namespace CSharpModule12.Models
{
    internal class Client : ViewModel
    {
        public Client(string firstName, string lastName)
        {
            this._id = NextId();
            this._firstName = firstName;
            this._lastName = lastName;
            this._clientBankAccounts = new List<BankAccount>();
        }
        static Client()
        {
            _clientId = 0;
        }
       
        private static int _clientId;
        private int _id;
        private string _firstName;
        private string _lastName;
        private List<BankAccount> _clientBankAccounts;
        public int Id { get => _id; private set => Set(ref _id, value); }
        public string FirstName { get => _firstName; private set => Set(ref _firstName, value); }
        public string LastName { get => _lastName; private set => Set(ref _lastName, value); }
        public List<BankAccount> ClientBankAccounts { get => _clientBankAccounts; private set => Set(ref _clientBankAccounts, value); }

        public void CreateBankAccount(double money)
        {
            ClientBankAccounts.Add(new BankAccount(money));
        }
        private static int NextId()
        {
            _clientId++;
            return _clientId;
        }
    }
}
