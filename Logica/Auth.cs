using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using MD5Hash;

namespace Logica
{
    class Auth
    {
        public static Dictionary<string, string> Login(string correo, string password)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            UserModel user = new UserModel
            {
                Correo = correo
            };


            if (user.GetUser() && Hash.Content(password) == user.Contrasena)
            {
                if (user.Deshabilitado)
                {
                    result.Add("status", "Usuario deshabilitado");
                    return result;
                }

                result.Add("Id", user.Id.ToString());
                result.Add("Correo", user.Correo);
                result.Add("Rol", user.Rol);
                result.Add("status", "OK");
                return result;
            }

            result.Add("status", "Credenciales invalidas");
            return result;
        }
    }
}
