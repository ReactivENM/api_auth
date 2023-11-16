using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MD5Hash;


namespace Datos
{
    public class UserModel
    {

        public string Correo;
        public string Contrasena;
        public bool Deshabilitado;

        public int Id;
        public string Rol;

        public bool GetUser()
        {
            using (Model model = new Model())
            {
                model.Command.CommandText = $"SELECT id, correo, contrasena, rol, deshabilitado " + $"FROM usuario WHERE correo = '{this.Correo}'";
                model.Reader = model.Command.ExecuteReader();

                if (model.Reader.HasRows)
                {
                    model.Reader.Read();
                    this.Id = Int32.Parse(model.Reader["id"].ToString());
                    this.Correo = model.Reader["correo"].ToString();
                    this.Contrasena = model.Reader["contrasena"].ToString();
                    this.Rol = model.Reader["rol"].ToString();
                    this.Deshabilitado = bool.Parse(model.Reader["deshabilitado"].ToString());
                    return true;
                }

                return false;
            }
        }

    }

}
