using DbHelper;
using EntityBase;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            //_jwtTokenHandler = jwtTokenHandler;
            _context = context;
        }
        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<AuthenticationResponse?> Authenticate(AuthenticationRequest authenticationRequest)
        {
            AccountDbHelper obj =new AccountDbHelper(_context);
            JwtTokenHandler jwt = new JwtTokenHandler(_context);
            var authenticationResponse = jwt.GenerateJwtToken(authenticationRequest);
            if (authenticationResponse == null) return Unauthorized();
            return authenticationResponse;
        }
    }
}
