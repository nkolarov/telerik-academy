using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Expenses
    {
        public int ID { get; set; }

        public string VendorName { get; set; }

        public DateTime Month { get; set; }

        public decimal expenses { get; set; }

    }
}
