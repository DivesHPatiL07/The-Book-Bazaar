using System;
using System.Collections.Generic;

namespace BookStore.Web_App.Models
{
    public partial class Orderitem
    {
        public int Id { get; set; }
        public int? Orderid { get; set; }
        public int? Bookid { get; set; }
        public int? Quantity { get; set; }
        public int? Subtotal { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Order? Order { get; set; }
    }
}
