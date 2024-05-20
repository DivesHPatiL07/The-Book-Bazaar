using Data_Models;
using EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View_Models;

namespace DbHelper
{
    public class AuthDbHelper
    {
        private readonly AppDbContext _context;
        public AuthDbHelper(AppDbContext context)
        {
            _context = context;
        }
        public bool ValidateUser(AuthenticationRequest authenticationRequest, out InformationTransaction info)
        {
            AuthDbService dbService = new AuthDbService(_context);
            return dbService.ValidateUser(authenticationRequest, out info);
        }
    }
}
