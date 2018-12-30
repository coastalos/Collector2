using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collector.Models
{
    public enum DepositorType
    {
        Owner,
        CoOwner,
        Agent,
        Beneficiary
    }

    public class Depositors
    {
        //public int ID { get; set; }
        public int MemberID { get; set; }
        [ForeignKey("MemberID")]
        public Member Member { get; set; }
        public int DepositID { get; set; }
        [ForeignKey("DepositID")]
        public Deposit Deposit { get; set; }
        public string Title { get; set; }
        public DepositorType Type { get; set; }
    }
}
