using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View_Models
{
    public class SaveAuthorModel
    {
        public int ID { get; set; }
        public string? NAME { get; set; }
        public string? BIO { get; set; }
        public char? ACTION { get; set; }
    }
}
