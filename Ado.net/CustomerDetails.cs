using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net
{
    internal class CustomerDetails
    {
        public int CustomerId {get; set;}
        public string CustomerName { get; set;}
        public long Phone { get; set;}
        public string Address { get; set;}
        public string Country { get; set;}
        public int Salary { get; set;}
        public int Pincode { get; set;}

        public override string ToString()
        {
            return $"{CustomerName} {Phone} {Address} {Country} {Salary} {Pincode}";
        }
    }
}
