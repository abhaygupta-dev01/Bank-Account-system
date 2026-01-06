using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using BankAssignment.Data;
using BankAssignment.Models;

namespace BankAssignment.Views
{
    public partial class AccountManagementView : UserControl
    {
        private Account? _selectedAccount = null;

        public AccountManagementView() { InitializeComponent(); }

        private void CreateAccount_Click(object sender, RoutedEventArgs e) { _selectedAccount = null; ClearForm(); MainTabControl.SelectedIndex = 0; }
        private void ModifyAccount_Click(object sender, RoutedEventArgs e)
        {
            _selectedAccount = dgAccounts.SelectedItem as Account;
            if (_selectedAccount == null) { MessageBox.Show("Please select an account from 'View Details' first."); return; }
            LoadFormFromSelected();
            MainTabControl.SelectedIndex = 0;
        }
        private void ViewDetails_Click(object sender, RoutedEventArgs e) { RefreshGrid(); MainTabControl.SelectedIndex = 1; }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirst.Text.Trim().Length < 3 || txtLast.Text.Trim().Length < 3)
            {
                MessageBox.Show("Names must be at least 3 characters."); return;
            }
            if (!Regex.IsMatch(txtPan.Text.ToUpper(), @"^[A-Z]{5}[0-9]{4}[A-Z]{1}$"))
            {
                MessageBox.Show("Invalid PAN Format (e.g. ABCDE1234F)"); return;
            }
            if (!Regex.IsMatch(txtMobile.Text, @"^[6-9]\d{9}$"))
            {
                MessageBox.Show("Enter valid mobile no ( e.g. 9876543210)"); return;
            }
            if (dtpDOB.SelectedDate == null) return;
            int age = DateTime.Today.Year - dtpDOB.SelectedDate.Value.Year;
            if (age < 5 || age > 80) { MessageBox.Show("Age must be between 5 and 80."); return; }

            using (var db = new BankDbContext())
            {
                if (_selectedAccount == null)
                {
                    var acc = new Account
                    {
                        AccountType = (cmbType.SelectedItem as ComboBoxItem).Content.ToString()!.ToUpper(),
                        FirstName = txtFirst.Text.ToUpper(),
                        MiddleName = txtMiddle.Text?.ToUpper(),
                        LastName = txtLast.Text.ToUpper(),
                        DateOfBirth = dtpDOB.SelectedDate.Value,
                        Gender = rbMale.IsChecked == true ? "MALE" : "FEMALE",
                        PanNumber = txtPan.Text.ToUpper(),
                        CurrentAddress = txtCurrAddr.Text.ToUpper(),
                        PermanentAddress = txtPermAddr.Text.ToUpper(),
                        MobileNumber = txtMobile.Text
                    };
                    db.Accounts.Add(acc);
                }
                else
                {
                    var acc = db.Accounts.Find(_selectedAccount.AccountNumber);
                    if (acc != null)
                    {
                        acc.FirstName = txtFirst.Text.ToUpper();
                        acc.LastName = txtLast.Text.ToUpper();

                        acc.PanNumber = txtPan.Text.ToUpper();
                        acc.CurrentAddress = txtCurrAddr.Text.ToUpper();
                        acc.PermanentAddress = txtPermAddr.Text.ToUpper();
                        acc.MobileNumber = txtMobile.Text;
                        
                    }
                }
                db.SaveChanges();
                MessageBox.Show("Account is saved successfully");
                ViewDetails_Click(null, null);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var acc = (sender as Button).DataContext as Account;
            if (acc != null && MessageBox.Show("Confirm Delete?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (var db = new BankDbContext()) { db.Accounts.Remove(db.Accounts.Find(acc.AccountNumber)); db.SaveChanges(); }
                RefreshGrid();
            }
        }

        private void LoadFormFromSelected()
        {
            txtFirst.Text = _selectedAccount.FirstName;
            txtLast.Text = _selectedAccount.LastName;
            txtPan.Text = _selectedAccount.PanNumber;
            txtCurrAddr.Text = _selectedAccount.CurrentAddress;
            txtPermAddr.Text = _selectedAccount.PermanentAddress;
            txtMobile.Text = _selectedAccount.MobileNumber;
            dtpDOB.SelectedDate = _selectedAccount.DateOfBirth;
        }

        private void RefreshGrid() { using (var db = new BankDbContext()) dgAccounts.ItemsSource = db.Accounts.ToList(); }
        private void ClearForm_Click(object sender, RoutedEventArgs e) => ClearForm();
        private void ClearForm()
        {
            txtFirst.Text = txtMiddle.Text = txtLast.Text = txtPan.Text = "";
            txtCurrAddr.Text = txtPermAddr.Text = txtMobile.Text = "";
            dtpDOB.SelectedDate = null;
        }
    }
}