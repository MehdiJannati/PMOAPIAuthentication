using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace UI.WebApi.Estates.ViewModel
{
    public class LoginResponseViewModel
    {
        public LoginResponseViewModel()
        {

            this.Token = "";
            this.ResponseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public string Token { get; set; }
        public HttpResponseMessage ResponseMsg { get; set; }

    }
}