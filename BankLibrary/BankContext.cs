using BankLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class BankContext : DbContext
    {

        //Ctor
        public BankContext(DbContextOptions<BankContext> options)
            :base(options) 
        {
            Database.EnsureCreated();
        }        

        // DbSet
        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        #endregion

        //Fill with data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user1 = new User("Albert", 1);
            var user2 = new User("Bartosz", 2);
            var user3 = new User("Cezary", 3);


            modelBuilder.Entity<User>()
                .HasOne(e => e.BankAccount)
                .WithOne(e => e.User)
                .HasForeignKey<BankAccount>()
                  .IsRequired(false); 

            modelBuilder.Entity<User>().HasKey(p => p.Id);
                
            modelBuilder.Entity<User>().HasData(
                user1,
                user2,
                user3
            );            

            var bacc1 = new BankAccount(0, user1.Id, 1);
            var bacc2 = new BankAccount(10000, user2.Id, 2);
            var bacc3 = new BankAccount(50000, user3.Id, 3);


            modelBuilder.Entity<BankAccount>().HasKey(p => p.Id);
            modelBuilder.Entity<BankAccount>()
                .HasOne(e => e.User)
                .WithOne(e => e.BankAccount);
                
            modelBuilder.Entity<BankAccount>().HasData(
                bacc1,
                bacc2,
                bacc3                
            );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            if (baseDir.Contains("bin"))
            {
                int index = baseDir.IndexOf("bin");
                baseDir = baseDir.Substring(0, index);
            }

            optionsBuilder.UseSqlite($"Data Source={baseDir}\\RaionBankDb.db");

        }

    }
}
