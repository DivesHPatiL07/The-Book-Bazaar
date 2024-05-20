using Dapper;
using Data_Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View_Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EntityBase
{
    public class AdminDbService : DbHandlerBase
    {
        //public User GetDetails(int Id)
        //{
        //    var con = GetConnection();
        //    con.Open();
        //    User users = new User();
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE ID =" + Id, con);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        users.Id = (int)reader["Id"];
        //        users.Username = reader["USERNAME"].ToString();
        //        users.Email = reader["EMAIL"].ToString();
        //        users.Password = reader["PASSWORD"].ToString();
        //        users.Address = reader["ADDRESS"].ToString();
        //        users.Role = reader["ROLE"].ToString();
        //    }
        //    con.Close();
        //    return users;
        //}

        //public void SaveBook(BookSaveModel SaveBook, out InformationTransaction info)
        //{
        //    try
        //    {
        //        info = new InformationTransaction();
        //        var con = GetConnection();
        //        con.Open();

        //        var P = new DynamicParameters();
        //        P.Add("@P_ID", SaveBook.ROWID);
        //        P.Add("@P_TITLE", SaveBook.TITLE);
        //        P.Add("@P_AUTHORID", SaveBook.AUTHORID);
        //        P.Add("@P_GENRE", SaveBook.GENRE);
        //        P.Add("@P_DESCRIPTION", SaveBook.DESCRIPTION);
        //        P.Add("@P_ACTION", SaveBook.ACTION);
        //        P.Add("@P_COVERIMAGEURL", SaveBook.COVERIMAGEURL);
        //        P.Add("@P_PRICE", SaveBook.PRICE);
        //        P.Add("@P_PUBLICATIONDATE", SaveBook.PUBLICATIONDATE);
        //        P.Add("@O_ERRORMESSAGE", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        //        var query = con.Execute("PRC_BOOKS_IUD", P, commandType: CommandType.StoredProcedure);


        //        var message = P.Get<string>("@O_ERRORMESSAGE");
        //        if (message == null && message == "")
        //        {
        //            info.Success = false;
        //            info.Message = "Server Error";
        //        }
        //        else
        //        {
        //            info.Success = true;
        //            if (SaveBook.ACTION == 'I')
        //            {
        //                info.Message = "Data Saved successfully";
        //            }
        //            else if (SaveBook.ACTION == 'U')
        //            {
        //                info.Message = "Data Updated successfully";
        //            }
        //            else
        //            {
        //                info.Message = "Data Deleted successfully";
        //            }
        //        }


        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        info = new InformationTransaction();
        //        info.Success = false;
        //        info.Message = ex.Message;
        //    }


        //}
        public void SaveAuthor(SaveAuthorModel SaveAuthor, out InformationTransaction info)
        {
            try
            {
                info = new InformationTransaction();
                var con = GetConnection();
                con.Open();

                var P = new DynamicParameters();
                P.Add("@P_ID", SaveAuthor.ID);
                P.Add("@P_NAME", SaveAuthor.NAME);
                P.Add("@P_BIO", SaveAuthor.BIO);
                P.Add("@P_ACTION", SaveAuthor.ACTION);
                P.Add("@O_ERRORMESSAGE", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                var query = con.Execute("PRC_AUTHOR_IUD", P, commandType: CommandType.StoredProcedure);


                var message = P.Get<string>("@O_ERRORMESSAGE");
                if (message == null && message == "")
                {
                    info.Success = false;
                    info.Message = "Server Error";
                }
                else
                {
                    info.Success = true;
                    if (SaveAuthor.ACTION == 'I')
                    {
                        info.Message = "Data Saved successfully";
                    }
                    else if (SaveAuthor.ACTION == 'U')
                    {
                        info.Message = "Data Updated successfully";
                    }
                    else
                    {
                        info.Message = "Data Deleted successfully";
                    }
                }


                con.Close();
            }
            catch (Exception ex)
            {
                info = new InformationTransaction();
                info.Success = false;
                info.Message = ex.Message;
            }


        }
        public List<AuthorDataModel> GetAuthorList(out InformationTransaction info)
        {
            List<AuthorDataModel> authorList = new List<AuthorDataModel>();
            try
            {
                info = new InformationTransaction();
                var con = GetConnection();
                con.Open();

                var query = con.QueryMultiple("SELECT * FROM AUTHORS");

                authorList = query.Read<AuthorDataModel>().ToList();
                info.Success = true;

                con.Close();
            }
            catch (Exception ex)
            {
                info = new InformationTransaction();
                info.Success = false;
                info.Message = ex.Message;
            }

            return authorList;
        }
    }
}
