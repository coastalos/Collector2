using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collector.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string OrganizationName { get; set; }

        public string Name
        {
            get {
                if(String.IsNullOrEmpty(OrganizationName)){
                    if (String.IsNullOrEmpty(MiddleName))
                    {
                        return FirstName + " " + LastName;
                    }
                    else
                    {
                        return FirstName + " " + MiddleName + " " + LastName;
                    }
                }
                else
                {
                    return OrganizationName;
                }
            }
        }

        //The Client this member belongs too
        public int ClientID { get; set; }
        [Required]
        public Client Client { get; set; }

        //Client's contact
        //public ICollection<Client> Clients { get; set; }

        //Navigation
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<Borrowers> Borrowers { get; set; } = new List<Borrowers>();
        public ICollection<Depositors> Depositors { get; set; } = new List<Depositors>();

    }
}
