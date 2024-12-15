using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        //------------------------------------------------------------METODO PARA DEFINIR ROL USUARIO
        public bool EsAdministrador()
        {
            return Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        }

        public bool EsMedico()
        {
            return Rol.Trim().Equals("Medico", StringComparison.OrdinalIgnoreCase);
        }
    }
}