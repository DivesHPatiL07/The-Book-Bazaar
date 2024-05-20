using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Models
{
    public class SY_TBL_USERACCOUNT
    {
        [Key]
        public int ROWID { get; set; }//int
        public string? USERNAME { get; set; }//varchar
        public string? EMAIL { get; set; }//varchar
        public string? PASSWORD { get; set; }//varchar
        public string? FIRSTNAME { get; set; }//varchar
        public string? LASTNAME { get; set; }//varchar
        public DateTime? DATEOFBIRTH { get; set; }//date
        public string? GENDER { get; set; }//varchar
        public string? ADDRESS { get; set; }//varchar
        public string? PHONENUMBER { get; set; }//varchar
        public int ROLEID { get; set; }//int
        public string? ACCOUNTSTATUS { get; set; }//varchar
        public string? PROFILEPICTURE { get; set; }//varchar
        public DateTime? LASTLOGINDATE { get; set; }//datetime
        public DateTime? CREATEDDATE { get; set; }//datetime
        public DateTime? MODIFIEDDATE { get; set; }//datetime
        public int CREATEDBY { get; set; }//int
        //public int MODIFIEDBY { get; set; }//int
    }
}
