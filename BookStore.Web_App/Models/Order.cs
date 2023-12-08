using System;
using System.Collections.Generic;

namespace BookStore.Web_App.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderitems = new HashSet<Orderitem>();
        }

        public int Id { get; set; }
        public int? Userid { get; set; }
        public DateTime? Orderdate { get; set; }
        public int? Totalamount { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
