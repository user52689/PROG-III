using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int _id;
        private string _nombreUsuario;
        private string _contraseña;
        private string _rol;  // "Administrador" o "Medico"

        public Usuario(int id, string nombreUsuario, string contraseña, string rol)
        {
            _id = id;
            _nombreUsuario = nombreUsuario;
            _contraseña = contraseña;
            _rol = rol;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string NombreUsuario
        {
            get => _nombreUsuario;
            set => _nombreUsuario = value;
        }

        public string Contraseña
        {
            get => _contraseña;
            set => _contraseña = value;
        }

        public string Rol
        {
            get => _rol;
            set => _rol = value;
        }

        public bool EsAdministrador() => _rol == "Administrador";
        public bool EsMedico() => _rol == "Medico";
    }
}