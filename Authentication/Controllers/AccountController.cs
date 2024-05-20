using Data_Models;
using DbHelper;
using EntityBase;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using View_Models;
using WebApp_Common_Helper;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        //[HttpPost]
        //[Route("Authenticate")]
        //public ActionResult<AuthenticationResponse?> Authenticate(AuthenticationRequest authenticationRequest)
        //{
        //    AuthDbHelper obj = new AuthDbHelper(_context);
        //    InformationTransaction info = new InformationTransaction();
        //    if (!obj.ValidateUser(authenticationRequest, out info))
        //    {
        //        return Unauthorized();
        //    }
        //    JwtTokenHandler jwt = new JwtTokenHandler(_context);
        //    var authenticationResponse = jwt.GenerateJwtToken(authenticationRequest);
        //    //if (authenticationResponse == null) return Unauthorized();
        //    return authenticationResponse;
        //}
        [HttpPost]
        [Route("Authenticate")]
        public async Task<ActionResult> Authenticate(AuthenticationRequest authenticationRequest)
        {
            AuthDbHelper obj = new AuthDbHelper(_context);
            InformationTransaction info = new InformationTransaction();
            ApiReturnBase rtn = new ApiReturnBase();
            if (!obj.ValidateUser(authenticationRequest, out info))
            {
                rtn.Message = info.Message;
                rtn.Success = info.Success;
                rtn.Data = "";
                return Ok(rtn);
            }
            JwtTokenHandler jwt = new JwtTokenHandler(_context);
            var authenticationResponse = jwt.GenerateJwtToken(authenticationRequest);
            //if (authenticationResponse == null) return Unauthorized();


            rtn.Message = info.Message;
            rtn.Success = info.Success;
            rtn.Data = authenticationResponse;
            
            return Ok(rtn);
        }
    }
}
