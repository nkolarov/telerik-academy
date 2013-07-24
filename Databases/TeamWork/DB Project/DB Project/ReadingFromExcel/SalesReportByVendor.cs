using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingVendorsSalesReportXML
{
    class SalesReportByVendor
    {
        public string VendorName { get; set; }

        public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}
