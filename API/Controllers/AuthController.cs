using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        public IHttpActionResult Auth([FromBody]AuthModel auth)
        {
            Dictionary<string, string> result = Logica.AuthController.Login(auth.Correo, auth.Contrasena);
            if (result["status"] == "OK")
                return Ok(result);
            return Unauthorized();
        }
    }
}
