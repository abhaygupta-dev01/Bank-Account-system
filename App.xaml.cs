using System.Windows;
using BankAssignment.Data;
using BankAssignment.Models;
using System.Linq;

namespace BankAssignment
{
    public partial class App : Application  
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var db = new BankDbContext())
            {
                db.Database.EnsureCreated();
                if (!db.Users.Any())
                {
                    db.Users.Add(new User { UserID = "admin", Password = "123" });
                    db.SaveChanges();
                }
            }
        }
    }
}