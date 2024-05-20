using Data_Models;
using EntityBase;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using View_Models;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler : DbHandlerBase
    {
        public const string JWT_SECURITY_KEY = "yPkCqn4kSWLtaJwXvN2jGzpQRyTZ3gdXkt7FeBJP";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly AppDbContext context;
        public JwtTokenHandler(AppDbContext _context)
        {
            this.context = _context;
        }
        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
                return null;

            /*validation*/
            using (var connection = GetConnection())
            {
                //connection.Open();
                // Use the connection here
                //var userAccount = context.SY_TBL_USERACCOUNT.Where(x => x.USERNAME == authenticationRequest.UserName && x.PASSWORD == authenticationRequest.Password).FirstOrDefault();
                ////connection.Close();
                //if (userAccount == null) return null;
                var tokenExpireTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
                var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
                var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName)
            });

                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature);

                var securityTokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Subject = claimsIdentity,
                    Expires = tokenExpireTimeStamp,
                    SigningCredentials = signingCredentials
                };

                var JwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var securityToken = JwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                var token = JwtSecurityTokenHandler.WriteToken(securityToken);
                return new AuthenticationResponse
                {
                    UserName = authenticationRequest.UserName,
                    ExpiresIn = (int)tokenExpireTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                    JwtToken = token
                };
            } // The connection is automatically closed and disposed of at the end of the using block



        }
    }
}
