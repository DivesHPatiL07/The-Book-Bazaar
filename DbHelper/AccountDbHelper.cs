using EntityBase;
using JwtAuthenticationManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHelper
{
    public class AccountDbHelper
    {
        private readonly AppDbContext _context;
        public AccountDbHelper(AppDbContext context)
        {
            _context = context;
        }
        public bool ValidateUser(AuthenticationRequest authenticationRequest)
        {

            return true;
        }
    }
}
