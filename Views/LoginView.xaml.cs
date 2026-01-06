using BankAssignment.Data;
using BankAssignment.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace BankAssignment.Views
{
    public partial class LoginView : UserControl
    {
        private LoginViewModel _viewModel = new LoginViewModel();

        public LoginView()
        {
            InitializeComponent();
            this.DataContext = _viewModel; 
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.InputPassword = txtPassword.Password;

            using (var db = new BankDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == _viewModel.InputUserID && u.Password == _viewModel.InputPassword);
             // var user1 = db.Users.FirstOrDefault(u => u.UserID == _viewModel.InputUserID && u.Password == _viewModel.InputPassword);

                if (user != null)
                {
                    // Switch to Account Management Screen
                    var mainWindow = Window.GetWindow(this);
                    mainWindow.Content = new AccountManagementView();
                }
                else
                {
                    MessageBox.Show("Invalid User ID or Password");
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtUserId.Text = "";
            txtPassword.Password = "";
            _viewModel.ClearFields(); 
        }
    }
}