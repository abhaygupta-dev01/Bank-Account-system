using System;
using System.ComponentModel.DataAnnotations;

namespace BankAssignment.Models
{
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        public string AccountType { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "";
        public string PanNumber { get; set; } = "";
        public string CurrentAddress { get; set; } = "";
        public string PermanentAddress { get; set; } = "";
        public string MobileNumber { get; set; } = "";
    }
}