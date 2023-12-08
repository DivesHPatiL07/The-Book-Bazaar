using System;
using System.Collections.Generic;

namespace BookStore.Web_App.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public int? Bookid { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? Reviewdate { get; set; }

        public virtual Book? Book { get; set; }
        public virtual User? User { get; set; }
    }
}
