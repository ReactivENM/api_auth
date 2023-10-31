using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class AuthController
    {
        public static Dictionary<string, string> Login(string correo, string contrasena)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result = Auth.Login(correo, contrasena);
            return result;
        }
    }
}
