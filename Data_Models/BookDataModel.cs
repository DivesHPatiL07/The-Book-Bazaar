using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Models
{
    public class BookDataModel
    {
        public int ROWID { get; set; }//int
        public string? ROWIDSTR { get; set; }//int
        public string? TITLE { get; set; }//varchar
        public string? AUTHOR { get; set; }//varchar
        public string? GENRE { get; set; }//varchar
        public string? DESCRIPTION { get; set; }//text
        public int PRICE { get; set; }//decimal
        public DateTime? PUBLICATIONDATE { get; set; }//date
        public string? PUBLICATIONDATEDISP { get; set; }//date
        public string? LANGUAGE { get; set; }//varchar
        public string? PUBLISHER { get; set; }//varchar
        public int AVAILABILITY { get; set; }//int
        public decimal RATING { get; set; }//decimal
        public string? COVERIMAGEURL { get; set; }//varchar
        public decimal DISCOUNT { get; set; }//decimal
        public string? TAGS { get; set; }//varchar
    }
}
