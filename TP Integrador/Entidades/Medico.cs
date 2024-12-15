using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        public int Legajo { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Genero { get; set; }
        public int Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int Localidad { get; set; }
        public int Provincia { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public int Especialidad { get; set; }
        public bool Estado { get; set; }
        public List<(int dia, int hora)> Diaxhora { get; set; }
    }
}