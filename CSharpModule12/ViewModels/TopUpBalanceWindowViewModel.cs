using System;
using System.Windows;
using System.Windows.Input;
using CSharpModule12.Infrastructure.Commands;
using CSharpModule12.Models;
using CSharpModule12.ViewModels.Base;
using CSharpModule12.Views.Windows;

namespace CSharpModule12.ViewModels
{
    internal class TopUpBalanceWindowViewModel : ViewModel
    {
        public TopUpBalanceWindowViewModel(BankAccount bankAccount, TopUpBalanceWindow window)
        {
            this._window = window;
            this._bankAccount = bankAccount;
            this.BankAccountInfo = $"ID: {bankAccount.Id} Баланс: {bankAccount.Money}";
            TopUpYourBalanceCommand = new RelayCommand(OnTopUpYourBalanceExecuted, CanTopUpYourBalanceExecute);
        }

        private TopUpBalanceWindow _window;
        private BankAccount _bankAccount;
        private string _upMoney;

        public string UpMoney { get => _upMoney; set => Set(ref _upMoney, value); }
        public string BankAccountInfo { get; set; }

        /// <summary>
        /// Команда для подтверждения и пополнение счета
        /// </summary>
        public ICommand TopUpYourBalanceCommand { get; }
        private bool CanTopUpYourBalanceExecute(object p)
        {
            if(String.IsNullOrWhiteSpace(UpMoney))
            {
                return false;
            }
            return true;
        }
        private void OnTopUpYourBalanceExecuted(object p)
        {
            try
            {
                _bankAccount.AddMoney(double.Parse(UpMoney));
                _window.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка!"); }
        }

    }
}
