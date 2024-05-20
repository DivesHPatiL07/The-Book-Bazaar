using Data_Models;
using Microsoft.AspNetCore.Mvc;
using View_Models;
using WebApp_Common_Helper;

namespace Book_Store_WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AuthenticateUser(AuthenticationRequest authenticationRequest)
        {
            AuthorListDataModel rtnValues = new AuthorListDataModel();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppSettings.GateWayUrl + "Auth/");

                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(authenticationRequest).ToString(), System.Text.Encoding.UTF8, "application/json");

                //client.DefaultRequestHeaders.Add("Authorization", Request.Cookies["hrmsauth"].ToString());

                var responseTask = client.PostAsync("Authenticate", content);

                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<ApiReturnBase>();

                    AuthenticationResponse dModel = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthenticationResponse>(readTask.Result.Data.ToString());

                    Response.Cookies.Append("bookBazaarAuth", dModel.JwtToken);
                    ViewData["LoginSuccess"] = readTask.Result.Success;
                    ViewData["LoginMassage"] = readTask.Result.Message;

                    return View("Login");
                    //if (readTask.Result.Success)
                    //{

                    //    return RedirectToAction("Index", "Home");
                    //}
                    //else
                    //{
                    //    return View("Login");
                    //}
                }
                else
                {
                    //throw new Exception(result.ReasonPhrase);
                    return View("Login");
                }
            }


        }
    }
}
