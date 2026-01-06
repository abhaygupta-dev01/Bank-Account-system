using BankAssignment.Data;
using System.Linq;
using System.Windows;

namespace BankAssignment.ViewModels
{
    public class LoginViewModel
    {
        public string InputUserID { get; set; }
        public string InputPassword { get; set; }

        public void ExecuteLogin()
        {
            using (var db = new BankDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == InputUserID && u.Password == InputPassword);

                if (user != null)
                {
                    MessageBox.Show("Login Successful!");
                }
                else
                {
                    MessageBox.Show("Invalid Credentials. Please try again.");
                }
            }
        }

        public void ClearFields()
        {
            InputUserID = string.Empty;
            InputPassword = string.Empty;
            MessageBox.Show("Fields Cleared");
        }
    }
}