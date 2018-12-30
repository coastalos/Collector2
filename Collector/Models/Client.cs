using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collector.Models
{
    public enum ClientType
    {
        Administrator,
        Contact,
        CareOf
    }
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        //Administrator of Contact Person
        //public int? MemberID { get; set; }
        //public Member Administrator { get; set; }
        //public ClientType Type { get; set; }

        //Members/Customers of this client
        public ICollection<Member> Members { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Deposit> Deposits { get; set; }

        //Address and Contact information from Contacts
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
