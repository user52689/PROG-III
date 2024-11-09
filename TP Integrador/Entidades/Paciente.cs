using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private string _DNI;
        private string _Nombre;
        private string _Apellido;
        private string _Genero;
        private string _Nacionalidad;
        private DateTime _FechaNacimiento;
        private string _Direccion;
        private string _Localidad;
        private string _Provincia;
        private string _CorreoElectronico;
        private string _Telefono;

        public string DNI { get => _DNI; set => _DNI = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Genero { get => _Genero; set => _Genero = value; }
        public string Nacionalidad { get => _Nacionalidad; set => _Nacionalidad = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Localidad { get => _Localidad; set => _Localidad = value; }
        public string Provincia { get => _Provincia; set => _Provincia = value; }
        public string CorreoElectronico { get => _CorreoElectronico; set => _CorreoElectronico = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
    }
}
