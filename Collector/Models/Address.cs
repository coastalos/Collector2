using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collector.Models
{
    public enum AddressType
    {
        Mailling,
        Physical,
        Alternative
    }
    public class Address
    {
        public int ID { get; set; }
        public int Order { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string PostalCode2 { get; set; }
        public AddressType Type { get; set; }

        //And address belongs to a Member, a Client, or a Collateral.
        public int? MemberID { get; set; }
        public Member Member { get; set; }

        public int? ClientID { get; set; }
        public Client Client { get; set; }

        public ICollection<Collateral> Collaterals { get; set; }

    }
}
