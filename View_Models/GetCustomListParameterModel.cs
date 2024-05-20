using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View_Models
{
    public class GetCustomListParameterModel
    {
        public string TableName { get; set; }
        public string ColumnsToSelect { get; set; }
        public string? WhereCondition { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string OrderByColumn { get; set; }
        public string SortOrder { get; set; }
    }
}
