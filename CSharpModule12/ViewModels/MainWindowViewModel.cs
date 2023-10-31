using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CSharpModule12.Infrastructure.Commands;
using CSharpModule12.Models;
using CSharpModule12.ViewModels.Base;
using CSharpModule12.Views.Windows;

namespace CSharpModule12.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            _clientsRepository = new Repository<Client>(path);
            Clients = _clientsRepository.Clients;

            OpenOrCloseBankAccountCommand = new RelayCommand(OnOpenOrCloseBankAccountExecuted, CanOpenOrCloseBankAccountExecute);
            TopUpBalanceCommand = new RelayCommand(OnTopUpBalanceExecuted, CanTopUpBalanceExecute);
            TransactionCommand = new RelayCommand(OnTransactionExecuted);

            _employee = new Consultant(Employee.EmployeeName.Consultant, "Анатолий", "Цой");

            //for (int i = 0; i < 20; i++)
            //{
            //    Clients.Add(new Client($"Имя_{i}", $"Фамилия_{i}"));
            //    Clients[i].CreateBankAccounts(2000 * i);
            //}
            //_clientsRepository.Save();
        }

        private Employee _employee { get; set; }
        private readonly string path = "clients.json";
        private Client _currentClient;
        private BankAccount _currentBankAccount;
        private Repository<Client> _clientsRepository;
        private ObservableCollection<BankAccount> _bankAccounts;
        private ObservableCollection<string> _currentChangesInfo;
        private string _currentBankAccountInfo;

        public ObservableCollection<string> CurrentChangesInfo { get => _currentChangesInfo; set => Set(ref _currentChangesInfo, value); }
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

        public static event Action<string> OpenOrCloseBankAccountInfo;

        /// <summary>
        /// Команда на открытие/закрытие счета
        /// </summary>
        public ICommand OpenOrCloseBankAccountCommand { get; }
        private bool CanOpenOrCloseBankAccountExecute(object p)
        {
            if(SelectedCurrentBankAccount != null)
            {
                return true;
            }
            return false;
        }
        private void OnOpenOrCloseBankAccountExecuted(object p)
        {
            SelectedCurrentBankAccount.OpenOrCloseBankAccount();
            UpdateBankAccountInfo();
            string info = SelectedCurrentBankAccount.IsOpen ? "закрыл" : "открыл";
            OpenOrCloseBankAccountInfo?.Invoke($"{_employee.DisplayEmployeeName()}: {_employee.FirstName} {_employee.LastName} {info} банковский счет.");
        }
        /// <summary>
        /// Команда пополнить счет
        /// </summary>
        public ICommand TopUpBalanceCommand { get; }
        private bool CanTopUpBalanceExecute(object p)
        {
            if (SelectedCurrentBankAccount != null)
            {
                return true;
            }
            return false;
        }
        private void OnTopUpBalanceExecuted(object p)
        {
            TopUpBalanceWindow topUpBalance = new TopUpBalanceWindow();
            TopUpBalanceWindowViewModel topUpBalanceViewModel = new TopUpBalanceWindowViewModel(_employee, SelectedCurrentBankAccount, topUpBalance);
            topUpBalance.DataContext = topUpBalanceViewModel;
            topUpBalance.ShowDialog();
            UpdateBankAccountInfo();
            _clientsRepository.Save();
        }
        /// <summary>
        /// Перевод средств
        /// </summary>
        public ICommand TransactionCommand { get; }
        private void OnTransactionExecuted(object p)
        {
            TransactionWindow transaction = new TransactionWindow();
            TransactionWindowViewModel transactionViewModel = new TransactionWindowViewModel(_employee, SelectedCurrentBankAccount, transaction, Clients);
            transaction.DataContext = transactionViewModel;
            transaction.ShowDialog();
            UpdateBankAccountInfo();
            _clientsRepository.Save();
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

            CurrentChangesInfo = _employee.ChangesInfo;

            string currentBankAccountStatus = SelectedCurrentBankAccount.IsOpen ? "Открыт" : "Закрыт";
            string currentBankAccountType = SelectedCurrentBankAccount.BankAccountType == 0 ? "Депозитный" : "Недепозитный";
            Debug.WriteLine(SelectedCurrentBankAccount.BankAccountType);
            CurrentBankAccountInfo =
                $"ID: {SelectedCurrentBankAccount.Id} Тип: {currentBankAccountType}\n" +
                $"Статус: {currentBankAccountStatus}\n" +
                $"Колличество средств: {SelectedCurrentBankAccount.Money}";
        }
    }
}
