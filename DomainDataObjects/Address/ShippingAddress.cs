using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDataObjects.Address
{
    public class ShippingAddress
    {
        public Guid ShippingAddressID { get; set; }
        public string ShippingAddress_HouseNumber { get; set; }
        public string ShippingAddress_Street { get; set; }
        public string ShippingAddress_City { get; set; }
        public string ShippingAddress_State { get; set; }
        public string ShippingAddress_Country { get; set; }
        public string ShippingAddress_PostalCode { get; set; }
    }
}
