using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Models
{
    public class BookListDataModel
    {
        public List<BookDataModel> rows { get; set; }
        public int total { get; set; }
        public BookListDataModel()
        {
            rows = new List<BookDataModel>();
        }
    }
}
