using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary.Models
{
    public class BankAccount
    {
        public BankAccount()
        {
            
        }
        public BankAccount(decimal saldo, int id)
        {          
            Saldo = saldo;                 
            UserId = id;
        }
        //For mock reasons
        public BankAccount(decimal saldo, int userId, int id)
        {
            Saldo = saldo;
            Id = id;
            UserId = userId;
        }
        [Key]
        public int Id { get; set; }
        public decimal? Saldo { get; set; }
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
