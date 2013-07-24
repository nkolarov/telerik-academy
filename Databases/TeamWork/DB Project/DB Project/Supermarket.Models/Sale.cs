using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Sale
    {
        public int ID { get; set; }

        public string SupermarketName { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Sum { get; set; }

        public DateTime Date { get; set; }
    }
}
