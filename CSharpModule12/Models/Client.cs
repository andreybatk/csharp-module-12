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
