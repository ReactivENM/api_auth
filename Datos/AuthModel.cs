using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5Hash;

namespace Datos
{
    class AuthModel
    {
        public static Dictionary<string, string> Login(string correo, string password)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            UserModel user = new UserModel
            {
                Correo = correo
            };


            if (user.GetUser() && Hash.Content(password) == user.Contrasena)
            {
                resultado.Add("id", user.Id.ToString());
                resultado.Add("correo", user.Correo);
                resultado.Add("rol", user.Rol);
                resultado.Add("status", "OK");
                return resultado;
            }

            resultado.Add("status", "Credenciales invalidas o usuario no existente!");
            return resultado;
        }
    }
}
