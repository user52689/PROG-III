using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosUsuario
    {
        AccesoDatos ad = new AccesoDatos();

        public Usuario ObtenerUsuario(string nombreUsuario, string contraseña)
        {
            string consulta = "SELECT * FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", contraseña);

            DataTable dt = ad.ObtenerTablaConComando("Usuarios", cmd);
            if (dt.Rows.Count > 0)
            {
                return new Usuario(
                    Convert.ToInt32(dt.Rows[0]["Id"]),
                    dt.Rows[0]["NombreUsuario"].ToString(),
                    dt.Rows[0]["Contraseña"].ToString(),
                    dt.Rows[0]["Rol"].ToString()
                );
            }
            return null;
        }
    }
}