using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CSharpModule12.Infrastructure.Commands;
using CSharpModule12.DAL.Exceptions;
using CSharpModule12.DAL.Models;
using CSharpModule12.ViewModels.Base;
using CSharpModule12.Views.Windows;

namespace CSharpModule12.ViewModels
{
    public class TransactionWindowViewModel : ViewModel
    {
        public TransactionWindowViewModel(Employee employee, BankAccount bankAccount, TransactionWindow window, ObservableCollection<Client> clients)
        {
            string currentBankAccountType = bankAccount.BankAccountType == 0 ? "Депозитный" : "Недепозитный";
            this._employee = employee;
            this._window = window;
            this._bankAccount = bankAccount;
            this.Clients = clients;
            this.BankAccountInfo = $"ID: {bankAccount.Id} Баланс: {bankAccount.Money} Тип: {currentBankAccountType}";
            TransactionCommand = new RelayCommand(OnTransactionExecuted, CanTransactionExecute);
        }

        private Employee _employee;
        private TransactionWindow _window;
        private BankAccount _bankAccount;
        private BankAccount _currentBankAccount;
        private ObservableCollection<BankAccount> _bankAccounts;
        private Client _currentClient;
        private string _upMoney;

        public ObservableCollection<BankAccount> BankAccounts { get => _bankAccounts; set => Set(ref _bankAccounts, value); }
        public ObservableCollection<Client> Clients { get; private set; }
        public string UpMoney { get => _upMoney; set => Set(ref _upMoney, value); }
        public string BankAccountInfo { get; set; }
        public static event Action<string> TransactionInfo;

        public Client SelectedCurrentClient
        {
            get
            {
                return _currentClient;
            }
            set
            {
                Set(ref _currentClient, value);
                BankAccounts = SelectedCurrentClient.ClientBankAccounts;
                SelectedCurrentBankAccount = BankAccounts[0];
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
            }
        }

        /// <summary>
        /// Команда для подтверждения и перевода средств
        /// </summary>
        public ICommand TransactionCommand { get; }
        private bool CanTransactionExecute(object p)
        {
            if (String.IsNullOrWhiteSpace(UpMoney))
            {
                return false;
            }
            return true;
        }
        private void OnTransactionExecuted(object p)
        {
            try
            {
                _bankAccount.MoneyTransfer(SelectedCurrentBankAccount, double.Parse(UpMoney));
                TransactionInfo?.Invoke($"{_employee.DisplayEmployeeName()}: {_employee.FirstName} {_employee.LastName} " +
                    $"перевел с банковского счета {_bankAccount.Id} на {SelectedCurrentBankAccount.Id} : {UpMoney} средств.");
                _window.Close();
            }
            catch (MismatchBankAccountTypeException ex) { MessageBox.Show(ex.Message, "Ошибка!"); }
            catch (InsufficientExecutionStackException ex) { MessageBox.Show(ex.Message, "Ошибка!"); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка!"); }
        }
    }
}
