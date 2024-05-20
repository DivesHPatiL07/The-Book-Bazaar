using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Models
{
    public class AuthorListDataModel
    {
        public List<AuthorDataModel> rows { get; set; }
        public int total { get; set; }
        public AuthorListDataModel()
        {
            rows = new List<AuthorDataModel>();
        }
    }
}
