using Dapper;
using Data_Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using View_Models;
using static System.Collections.Specialized.BitVector32;

namespace EntityBase
{
    public class BookDbService : DbHandlerBase
    {
        private readonly AppDbContext _context;
        public BookDbService(AppDbContext context)
        {
            _context = context;
        }
        public BookListDataModel GetBookList(GetCustomListParameterModel para, out InformationTransaction info)
        {
            BookListDataModel rtnData = new BookListDataModel();
            try
            {
                info = new InformationTransaction();
                var con = GetConnection();
                con.Open();

                var P = new DynamicParameters();
                P.Add("@TableName", para.TableName);
                P.Add("@ColumnsToSelect", para.ColumnsToSelect);
                P.Add("@WhereCondition", para.WhereCondition);
                P.Add("@PageSize", para.PageSize);
                P.Add("@PageNumber", para.PageNumber);
                P.Add("@OrderByColumn", para.OrderByColumn);
                P.Add("@SortOrder", para.SortOrder);
                P.Add("@TotalRecords", dbType: DbType.String, direction: ParameterDirection.Output, size: 8000);
                var query = con.QueryMultiple(sql: "SY_PRC_GETCUSTOMRECORD", P, commandType: System.Data.CommandType.StoredProcedure);

                rtnData.rows = query.Read<BookDataModel>().ToList();
                rtnData.total = Convert.ToInt32(P.Get<string>("@TotalRecords"));
                info.Success = true;

                con.Close();
            }
            catch (Exception ex)
            {
                info = new InformationTransaction();
                info.Success = false;
                info.Message = ex.Message;
            }

            return rtnData;
        }
        public void SaveBook(BookSaveModel para, out InformationTransaction info)
        {
            try
            {
                info = new InformationTransaction();
                var con = GetConnection();
                con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@P_ROWID", para.ROWID);
                parameters.Add("@P_TITLE", para.TITLE);
                parameters.Add("@P_AUTHOR", para.AUTHOR);
                parameters.Add("@P_GENRE", para.GENRE);
                parameters.Add("@P_DESCRIPTION", para.DESCRIPTION);
                parameters.Add("@P_PRICE", para.PRICE);
                parameters.Add("@P_PUBLICATIONDATE", para.PUBLICATIONDATE);
                parameters.Add("@P_LANGUAGE", para.LANGUAGE);
                parameters.Add("@P_PUBLISHER", para.PUBLISHER);
                parameters.Add("@P_AVAILABILITY", para.AVAILABILITY);
                parameters.Add("@P_RATING", para.RATING);
                parameters.Add("@P_COVERIMAGEURL", para.COVERIMAGEURL);
                parameters.Add("@P_DISCOUNT", para.DISCOUNT);
                parameters.Add("@P_TAGS", para.TAGS);
                parameters.Add("@P_CREATEDBY", para.CREATEDBY);
                parameters.Add("@P_ACTION", para.ACTION);

                con.Execute("MS_PRC_BOOKS_IUD", parameters, commandType: CommandType.StoredProcedure);
                info.Success = true;
            }
            catch (Exception ex)
            {
                info = new InformationTransaction();
                info.Success = false;
                info.Message = ex.Message;
            }
        }
    }
}
