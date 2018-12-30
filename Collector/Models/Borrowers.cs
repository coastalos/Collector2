using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collector.Models
{
    public enum BorrowerType {
        Borrower,
        CoBorrower
    }

    public class Borrowers
    {
        public int MemberID { get; set; }
        [ForeignKey("MemberID")]
        public Member Member { get; set; }
        public int LoanID { get; set; }
        [ForeignKey("LoanID")]
        public Loan Loan { get; set; }
        public BorrowerType Type { get; set; }
    }
}
