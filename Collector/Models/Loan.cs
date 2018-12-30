using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collector.Models
{
    public enum LoanSatus
    {
        Active,
        Inactive,
        Closed,
        PendingChargeOff,
        ChargedOff,
        FullRecovery,
        PartialRecovery,
        Settled
    }

    public class Loan
    {
        public int ID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; } //Account type is client defined, e.g. Consumer, Commercial, Credit Card, etc.
        public string ProductName { get; set; }
        public int? Term { get; set; }
        public double? InterestRate { get; set; }
        public int? CreditScore { get; set; }
        public string AccountStatus { get; set; }
        public LoanSatus Status { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime FirstPaymentDate { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime LastImportDate { get; set; }
        public DateTime LastMaintenanceDate { get; set; }

        public int DaysPastDue
        {
            get
            {
                return (DateTime.Now - DueDate).Days;
            }
        }

        public double TotalDueAmount { get; set; }
        public double DuePrincipal { get; set; }
        public double DueInterest { get; set; }
        public double DueLateCharges { get; set; }
        public double DueEscrow { get; set; }

        public double OriginalAmount { get; set; }
        public double PrincipalAmount { get; set; }
        public double? CreditLimit { get; set; }
        public double? EscrowBalance { get; set; }
        public double? AmountInSuspense { get; set; }
        public double? LastPaymentAmount { get; set; }
        public double? MonthlyPayment { get; set; }
        public double? TodaysPayOffAmount { get; set; }
        public double? PierDiem { get; set; }
        public double? ChargedOffAmount { get; set; }

        public int? TimesLate30Days { get; set; }
        public int? TimesLate60Days { get; set; }
        public int? TimesLate90Days { get; set; }
        public int? TimesLate180days { get; set; }

        public int ClientID { get; set; }
        [Required]
        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        public ICollection<Collateral> Collaterals { get; set; } = new List<Collateral>();
        public ICollection<Borrowers> Borrowers { get; set; } = new List<Borrowers>();
    }
}
