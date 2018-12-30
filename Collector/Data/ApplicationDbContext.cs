using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Collector.Models;

namespace Collector.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Collateral> Collaterals { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Borrowers> Borrowers { get; set; }
        public DbSet<Depositors> Depositors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Borrowers>()
                .HasKey(bl => new { bl.LoanID, bl.MemberID });
            modelBuilder.Entity<Borrowers>()
                .HasOne(bl => bl.Loan)
                .WithMany(b => b.Borrowers)
                .HasForeignKey(bl => bl.LoanID);
            modelBuilder.Entity<Borrowers>()
                .HasOne(bl => bl.Member)
                .WithMany(m => m.Borrowers)
                .HasForeignKey(bl => bl.MemberID)
                .OnDelete(DeleteBehavior.Restrict); //On Bridge (Many-To-Many) Tables include OnDelete(DeleteBehavior.Restrict) to avoid
            //cascade deletion of relation members, in this example Loans and Members.

            modelBuilder.Entity<Depositors>()
                .HasKey(bl => new { bl.DepositID, bl.MemberID });
            modelBuilder.Entity<Depositors>()
                .HasOne(bl => bl.Deposit)
                .WithMany(b => b.Depositors)
                .HasForeignKey(bl => bl.DepositID);
            modelBuilder.Entity<Depositors>()
                .HasOne(bl => bl.Member)
                .WithMany(m => m.Depositors)
                .HasForeignKey(bl => bl.MemberID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
