﻿using System;
using System.Windows;
using System.Windows.Input;
using CSharpModule12.Infrastructure.Commands;
using CSharpModule12.DAL.Models;
using CSharpModule12.ViewModels.Base;
using CSharpModule12.Views.Windows;

namespace CSharpModule12.ViewModels
{
    public class TopUpBalanceWindowViewModel : ViewModel
    {
        private Employee _employee;
        private TopUpBalanceWindow _window;
        private BankAccount _bankAccount;
        private string _upMoney;

        public TopUpBalanceWindowViewModel(Employee employee, BankAccount bankAccount, TopUpBalanceWindow window)
        {
            this._employee = employee;
            this._window = window;
            this._bankAccount = bankAccount;
            this.BankAccountInfo = $"ID: {bankAccount.Id} Баланс: {bankAccount.Money}";
            TopUpYourBalanceCommand = new RelayCommand(OnTopUpYourBalanceExecuted, CanTopUpYourBalanceExecute);
        }

        public string UpMoney { get => _upMoney; set => Set(ref _upMoney, value); }
        public string BankAccountInfo { get; set; }
        public static event Action<string> TopUpYourBalanceInfo;

        /// <summary>
        /// Команда для подтверждения и пополнение счета
        /// </summary>
        public ICommand TopUpYourBalanceCommand { get; }
        private bool CanTopUpYourBalanceExecute(object p)
        {
            if (String.IsNullOrWhiteSpace(UpMoney))
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
                TopUpYourBalanceInfo?.Invoke($"{_employee.DisplayEmployeeName()}: {_employee.FirstName} {_employee.LastName} пополнил счет на {UpMoney} средств.");
                _window.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка!"); }
        }
    }
}