using Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using View_Models;

namespace EntityBase
{
    public class AuthDbService : DbHandlerBase
    {
        private readonly AppDbContext _context;
        public AuthDbService(AppDbContext context)
        {
            _context = context;
        }

        public bool ValidateUser(AuthenticationRequest authenticationRequest, out InformationTransaction info)
        {
            info = new InformationTransaction();
            using (var connection = GetConnection())
            {
                connection.Open();
                // Use the connection here
                var userName = _context.SY_TBL_USERACCOUNT.Where(x => (x.USERNAME == authenticationRequest.UserName) || x.EMAIL == authenticationRequest.UserName).FirstOrDefault();


                if (userName == null)
                {
                    info.Success = false;
                    info.Message = "Invalid Username!";
                    return false;
                }
                else
                {
                    if (string.Equals(userName.USERNAME, authenticationRequest.UserName) || string.Equals(userName.EMAIL, authenticationRequest.UserName))
                    {

                    }
                    else
                    {
                        info.Success = false;
                        info.Message = "Invalid Username!";
                        return false;
                    }
                }
                var userAccount = _context.SY_TBL_USERACCOUNT.Where(x => (x.USERNAME == authenticationRequest.UserName || x.EMAIL == authenticationRequest.UserName) && x.PASSWORD == authenticationRequest.Password).FirstOrDefault();
                //connection.Close();
                if (userAccount == null)
                {
                    info.Success = false;
                    info.Message = "Invalid Password!";
                    return false;
                }
                else
                {
                    if (string.Equals(userName.PASSWORD, authenticationRequest.Password))
                    {

                    }
                    else
                    {
                        info.Success = false;
                        info.Message = "Invalid Password!";
                        return false;
                    }
                }
                info.Success = true;
                info.Message = "Login Successfully!";
                return true;

            }
        }
    }
}