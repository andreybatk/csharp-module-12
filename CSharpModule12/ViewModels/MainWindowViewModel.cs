using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpModule12.ViewModels.Base;
using CSharpModule12.Models;
using System.Collections.ObjectModel;
using System.Threading;
using System.Diagnostics;

namespace CSharpModule12.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            _clients = new Repository<Client>(path);
            Clients = _clients.Clients;
        }

        private Client _currentClient;
        private BankAccount _currentBankAccount;
        private Repository<Client> _clients;
        private readonly string path = "clients.json";
        private List<BankAccount> _bankAccounts;
        private string _currentBankAccountInfo;

        public ObservableCollection<Client> Clients { get; set; }
        public List<BankAccount> BankAccounts { get => _bankAccounts; set => Set(ref _bankAccounts, value); }
        public Client SelectedCurrentClient
        {
            get 
            {
                return _currentClient;
            }
            set
            {
                Set(ref _currentClient, value);
                UpdateBankAccounts();
            }
        }
        public BankAccount SelectedCurrentBankAccount
        {
            get
            {
                return _currentBankAccount;
            }
            set
            {
                Set(ref _currentBankAccount, value);
                UpdateBankAccountInfo();
            }
        }
        public string CurrentBankAccountInfo { get => _currentBankAccountInfo; set => Set(ref _currentBankAccountInfo, value); }
        private void UpdateBankAccounts()
        {
            if(_currentClient != null)
            {
                BankAccounts = _currentClient.ClientBankAccounts;
                SelectedCurrentBankAccount = BankAccounts[0];
            }
        }
        private void UpdateBankAccountInfo()
        {
            if (_currentBankAccount == null)
            {
                CurrentBankAccountInfo = "";
                return;
            }
            
            string currentBankAccountStatus = _currentBankAccount.IsOpen ? "Открыт" : "Закрыт";
            CurrentBankAccountInfo =
                $"ID: {_currentBankAccount.Id}\n" +
                $"Статус: {currentBankAccountStatus}\n" +
                $"Колличество средств: {_currentBankAccount.Money}";
        }
    }
}
