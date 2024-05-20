using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Models
{
    public class BookSaveModel
    {
        public int ROWID { get; set; }//int
        public string TITLE { get; set; }//varchar
        public string AUTHOR { get; set; }//varchar
        public string GENRE { get; set; }//varchar
        public string? DESCRIPTION { get; set; }//text
        public decimal PRICE { get; set; }//decimal
        public DateTime PUBLICATIONDATE { get; set; }//date
        public string? LANGUAGE { get; set; }//varchar
        public string? PUBLISHER { get; set; }//varchar
        public int AVAILABILITY { get; set; }//int
        public decimal RATING { get; set; }//decimal
        public string? COVERIMAGEURL { get; set; }//varchar
        public decimal DISCOUNT { get; set; }//decimal
        public string? TAGS { get; set; }//varchar
        public int CREATEDBY { get; set; }//int
        public char ACTION { get; set; }//char
    }
}
