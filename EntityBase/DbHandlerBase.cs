using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EntityBase
{
    public class DbHandlerBase
    {
        public static SqlConnection GetConnection()
        {
            string str = "Server=LAPTOP-GSDBM2F1\\SQLEXPRESS; database=BookBazaar; trusted_connection=true;";

            SqlConnection con = new SqlConnection(str);
            return con;
        }
    }
}
