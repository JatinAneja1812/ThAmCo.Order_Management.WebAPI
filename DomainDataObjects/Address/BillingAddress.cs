using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDataObjects.Address
{
    public class BillingAddress
    {
        public Guid BillingAddresssID { get; set; }
        public string BillingAddresss_HouseNumber { get; set; }
        public string BillingAddresss_Street { get; set; }
        public string BillingAddresss_City { get; set; }
        public string BillingAddresss_State { get; set; }
        public string BillingAddresss_Country { get; set; }
        public string BillingAddresss_PostalCode { get; set; }
    }
}
