using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collector.Models
{
    public enum DepositStatus
    {
        Open,
        Overdraft,
        ChargeOff,
        FullRecovery,
        PartialRecovery,
        Settled,
        Closed        
    }

    public class Deposit
    {
        public int ID { get; set; }
        public string AccountType { get; set; } //Account type is client defined, e.g. Consumer, Commercial, Credit Card, etc.
        public string ProductName { get; set; }
        public int? Term { get; set; }
        public double? InterestRate { get; set; }
        public string AccountStatus { get; set; }
        public DepositStatus Status { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime DateLastPositive { get; set; }
        public DateTime LastDepositDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime LastImportDate { get; set; }
        public DateTime LastMaintenanceDate { get; set; }

        public int DaysNegative {
            get {
                return (DateTime.Now - DateLastPositive).Days;
            }
        }

        public double TotalDueAmount { get; set; }
        public double DuePrincipal { get; set; }
        public double? DueLateCharges { get; set; }

        public double? AverageMonthlyBalance { get; set; }
        public double? AverageMonthlyDeposits { get; set; }
        public double? OpenDeposit { get; set; }
        public double? LastDepositAmount { get; set; }
        public double CurrentBalance { get; set; }
        public double UncollectableFunds { get; set; }

        public bool SocialSecuritDeposit { get; set; }
        public bool StudentLoanDeposit { get; set; }
        public bool VeteranDeposit { get; set; }

        public double CollectableFunds
        {
            get
            {
                if(SocialSecuritDeposit && StudentLoanDeposit && VeteranDeposit)
                {
                    return CurrentBalance - UncollectableFunds;
                }
                else
                {
                    return CurrentBalance;
                }
            }
        }

        public int? TimesLate30Days { get; set; }
        public int? TimesLate60Days { get; set; }
        public int? TimesLate90Days { get; set; }
        public int? TimesLate180days { get; set; }

        public int ClientID { get; set; }
        [Required]
        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        public ICollection<Depositors> Depositors { get; set; } = new List<Depositors>();
    }
}
