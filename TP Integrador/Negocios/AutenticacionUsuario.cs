using Datos;
using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class AutenticacionUsuario
    {
        private DatosUsuario datosUsuario = new DatosUsuario();

        public Usuario Login(string nombreUsuario, string contraseña)
        {
            return datosUsuario.ObtenerUsuarioPorCredenciales(nombreUsuario, contraseña);
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            Usuario usuarioExistente = datosUsuario.ObtenerUsuarioPorNombre(usuario.NombreUsuario);
            if (usuarioExistente != null)
            {
                return false; // Usuario ya existe
            }

            return datosUsuario.RegistrarUsuario(usuario);
        }
    }
}
