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
using System.Windows.Input;
using CSharpModule12.Infrastructure.Commands;

namespace CSharpModule12.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            _clients = new Repository<Client>(path);
            Clients = _clients.Clients;

            OpenOrCloseBankAccount = new RelayCommand(onOpenOrCloseBankAccountExecuted, canOpenOrCloseBankAccountExecute);

            //for (int i = 0; i < 20; i++)
            //{
            //    //Clients.Add(new Client($"Имя_{i}", $"Фамилия_{i}"));
            //    Clients[i].CreateBankAccount(2000 * i);
            //}
            //_clients.Save();
        }

        private readonly string path = "clients.json";
        private Client _currentClient;
        private BankAccount _currentBankAccount;
        private Repository<Client> _clients;
        private ObservableCollection<BankAccount> _bankAccounts;
        private string _currentBankAccountInfo;

        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<BankAccount> BankAccounts { get => _bankAccounts; set => Set(ref _bankAccounts, value); }
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
           
        /// <summary>
        /// Команда на открытие/закрытие счета
        /// </summary>
        public ICommand OpenOrCloseBankAccount { get; }
        private bool canOpenOrCloseBankAccountExecute(object p)
        {
            if(SelectedCurrentBankAccount != null)
            {
                return true;
            }
            return false;
        }
        private void onOpenOrCloseBankAccountExecuted(object p)
        {
            SelectedCurrentBankAccount.OpenOrCloseBankAccount();
            UpdateBankAccountInfo();
        }

        private void UpdateBankAccounts()
        {
            if(_currentClient != null)
            {
                BankAccounts = SelectedCurrentClient.ClientBankAccounts;
                SelectedCurrentBankAccount = BankAccounts[0];
            }
        }
        private void UpdateBankAccountInfo()
        {
            if (SelectedCurrentBankAccount == null)
            {
                CurrentBankAccountInfo = "";
                return;
            }

            string currentBankAccountStatus = SelectedCurrentBankAccount.IsOpen ? "Открыт" : "Закрыт";
            CurrentBankAccountInfo =
                $"ID: {SelectedCurrentBankAccount.Id}\n" +
                $"Статус: {currentBankAccountStatus}\n" +
                $"Колличество средств: {SelectedCurrentBankAccount.Money}";
        }
    }
}
