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

        //------------------------------------------------------------METODO PARA VERIFICACION DE USUARIO
        public Usuario Login(string nombreUsuario, string contraseña)
        {
            return datosUsuario.ObtenerUsuarioPorCredenciales(nombreUsuario, contraseña);
        }

        //------------------------------------------------------------METODO PARA REGISTRAR USUARIO
        public bool RegistrarUsuario(Usuario usuario)
        {
            Usuario usuarioExistente = datosUsuario.ObtenerUsuarioPorNombre(usuario.NombreUsuario);
            if (usuarioExistente != null)
            {
                return false; // Usuario ya existe
            }

            return datosUsuario.RegistrarUsuario(usuario);
        }

        //------------------------------------------------------------FUNCIONES PARA MODIFICACION DE USUARIO
        public List<Usuario> ObtenerUsuarios()
        {
            return datosUsuario.ListarUsuarios();
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            return datosUsuario.ModificarUsuario(usuario);
        }

        public bool NombreUsuarioExistente(string nombreUsuario, int userId)
        {
            return datosUsuario.VerificarNombreUsuarioExistente(nombreUsuario, userId);
        }

        // Este método maneja la validación de existencia y la actualización
        public bool ActualizarUsuarioConValidacion(int id, string nombreUsuario, string contraseña, string rol)
        {
            // Verificar si el nombre de usuario ya existe en la capa de datos
            bool nombreUsuarioExistente = datosUsuario.VerificarNombreUsuarioExistente(nombreUsuario, id);
            if (nombreUsuarioExistente)
            {
                return false; // El nombre de usuario ya está en uso
            }

            Usuario usuario = new Usuario
            {
                Id = id,
                NombreUsuario = nombreUsuario,
                Contraseña = contraseña,
                Rol = rol
            };

            // Llamar a la capa de datos para actualizar el usuario
            return datosUsuario.ModificarUsuario(usuario);
        }
    }


}
