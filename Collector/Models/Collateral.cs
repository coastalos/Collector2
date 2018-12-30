using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collector.Models
{
    public enum CollateralType
    {
        Address,
        VIN,
        Account,
        Other
    }

    public class Collateral
    {
        public int ID { get; set; }
        public int Order { get; set; }

        public CollateralType Type { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }

        public double? PropertyValue { get; set; }
        public double? PropertyPercentage { get; set; } //Percentage of the property to be used for collateral
        public string Position { get; set; } //Description of Position in Collateral

        public int? AddressID { get; set; }
        public Address Address { get; set; }

    }
}
