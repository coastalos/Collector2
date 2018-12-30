using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collector.Models
{
    public enum ContactType
    {
        Email,
        Phone
    }

    public class Contact
    {
        public int ID { get; set; }
        public int Order { get; set; }

        public string CountryCode { get; set; } //Country code for international phones
        public string RegionCode { get; set; } //Area or Regional Codes
        public string ContactInfo { get; set; } //Phone or Email, etc
        public string ContactDescription { get; set; } //Visual description of what this contact is
        public string ExtCode { get; set; }
        public bool? Fax { get; set; }
        public bool? SMS { get; set; }
        public bool? Mobile { get; set; }
        public ContactType Type { get; set; }

        public string ContactName
        {
            get
            {
                switch (Type)
                {
                    case ContactType.Phone:
                        return GetPhone();
                    case (ContactType.Email):
                        return GetEmail();
                    default:
                        return ContactInfo;
                }
            }
        }

        private string GetPhone()
        {
            string contact="";

            if (!String.IsNullOrEmpty(CountryCode))
            {
                contact = "+" + CountryCode;
            }

            if (!String.IsNullOrEmpty(RegionCode))
            {
                if (String.IsNullOrEmpty(contact))
                {
                    contact = RegionCode;
                }
                else
                {
                    contact = contact + " " + RegionCode;
                }
                
            }

            if (!String.IsNullOrEmpty(ExtCode))
            {
                if (String.IsNullOrEmpty(contact))
                {
                    contact = ContactInfo + "x" + ExtCode;
                }
                else
                {
                    contact = contact + "-" + ContactInfo + "x" + ExtCode;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(contact))
                {
                    contact = ContactInfo;
                }
                else
                {
                    contact = contact + "-" + ContactInfo;
                }
            }

            return contact;
        }

        private string GetEmail()
        {
            string contact;

            contact = ContactInfo;

            return contact;
        }

        //A Contact is either for a Member or a Client
        public int? MemberID { get; set; }
        public Member Member { get; set; }

        public int? ClientID { get; set; }
        public Client Client { get; set; }
    }
}
