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
    public class NegocioUsuario
    {
        private readonly DatosUsuario datosUsuario = new DatosUsuario();

        public Usuario Login(string nombreUsuario, string contraseña)
        {
            return datosUsuario.ObtenerUsuarioPorCredenciales(nombreUsuario, contraseña);
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            // Verificar si el usuario ya existe en la base de datos para evitar duplicados
            Usuario usuarioExistente = datosUsuario.ObtenerUsuarioPorNombre(usuario.NombreUsuario);
            if (usuarioExistente != null)
            {
                return false; 
            }

            // Registrar el usuario con la contraseña hasheada
            return datosUsuario.RegistrarUsuario(usuario);
        }
    }
}

