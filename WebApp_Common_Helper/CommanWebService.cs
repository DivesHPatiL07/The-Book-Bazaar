using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp_Common_Helper
{
    public static class CommanWebService
    {
        public static void whereClause(string columnName, string searchVal, ref string whereClause)
        {
            if (whereClause == "")
            {
                whereClause = columnName + " LIKE '%" + searchVal + "%'";
            }
            else
            {
                whereClause = whereClause + " OR " + columnName + " LIKE '%" + searchVal + "%'";
            }
        }
    }
}
