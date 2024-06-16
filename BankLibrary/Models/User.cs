using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary.Models
{
    public class User
    {       
        public User(string name)
        {           
            Name = name;           
        }

        // For mock reasons
        public User(string name, int id)
        {
            Id = id;
            Name = name;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public BankAccount? BankAccount { get; set; }
    }
}
