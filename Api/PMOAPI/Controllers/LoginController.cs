using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UI.WebApi.Estates.Helpers;
using UI.WebApi.Estates.ViewModel;

namespace UI.WebApi.Estates.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] LoginViewModel vm)
        {
            var loginResponse = new LoginResponseViewModel { };
            LoginViewModel loginRequest = new LoginViewModel { };
            loginRequest.Username = vm.Username.ToLower();
            loginRequest.Password = vm.Password;
            IHttpActionResult response;
            HttpResponseMessage responseMsg = new HttpResponseMessage();
            bool isUserNameandPasswordValid = false;
            if (vm != null)
            {
                isUserNameandPasswordValid = loginRequest.Password == "admin" ? true : false;
            }

            if (isUserNameandPasswordValid)
            {
                string token = TokenManager.CreateToken(loginRequest.Username);
                return Ok<string>(token);
            }
            else
            {
                loginResponse.ResponseMsg.StatusCode = HttpStatusCode.Unauthorized;
                response = ResponseMessage(loginResponse.ResponseMsg);
                return response;
            }
        }
    }
}
