using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFilling.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public string ProductId { get; set; } 
        public DateTime OrderDateTime { get; set; }
        public bool DeliveryStatus { get; set; }
        public string DeliveryBy { get; set; }
        public int Quantity { get; set; }
    }
}
