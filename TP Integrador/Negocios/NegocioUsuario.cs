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
        DatosUsuario datosUsuario = new DatosUsuario();

        public Usuario AutenticarUsuario(string nombreUsuario, string contraseña)
        {
            return datosUsuario.ObtenerUsuario(nombreUsuario, contraseña);
        }
    }
}

//public class AutenticacionUsuario /////De esta forma podemos hacer la autenticacion
//{
//    NegocioUsuario negocioUsuario = new NegocioUsuario();

//    public Usuario Login(string nombreUsuario, string contraseña)
//    {
//        return negocioUsuario.AutenticarUsuario(nombreUsuario, contraseña);
//    }
//}