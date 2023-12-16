using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrCodeFirst.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public double Discount { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public int PriceWithDiscount
        {
            get
            {
                return Convert.ToInt32(Price - Price * Discount);
            }
        }
    }
}
