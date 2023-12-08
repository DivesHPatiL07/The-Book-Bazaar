using System;
using System.Collections.Generic;

namespace BookStore.Web_App.Models
{
    public partial class Book
    {
        public Book()
        {
            Orderitems = new HashSet<Orderitem>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Authorid { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public string? Coverimageurl { get; set; }
        public int? Price { get; set; }
        public DateTime? Publicationdate { get; set; }

        public virtual Author? Author { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
