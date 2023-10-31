using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MD5Hash;


namespace Datos
{
    public class UserModel : Model
    {

        public string Correo;
        public string Contrasena;

        public int Id;
        public string Rol;

        public bool GetUser()
        {
            this.Command.CommandText = $"SELECT id, correo, contrasena, rol " + $"FROM usuario WHERE correo = '{this.Correo}'";
            this.Reader = this.Command.ExecuteReader();

            if (this.Reader.HasRows)
            {
                this.Reader.Read();
                this.Id = Int32.Parse(this.Reader["id"].ToString());
                this.Correo = this.Reader["correo"].ToString();
                this.Contrasena = this.Reader["contrasena"].ToString();
                this.Rol = this.Reader["rol"].ToString();
                return true;
            }

            return false;
        }

    }

}
