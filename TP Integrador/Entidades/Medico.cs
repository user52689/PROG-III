﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Medico
    {
        private string _Legajo;
        private string _DNI;
        private string _Nombre;
        private string _Apellido;
        private string _Sexo;
        private string _Nacionalidad;
        private DateTime _FechaNacimiento;
        private string _Direccion;
        private string _Localidad;
        private string _Provincia;
        private string _CorreoElectronico;
        private string _Telefono;
        private string _Especialidad;
        private string _DiasAtencion;
        private string _HorarioAtencion;

        public string Legajo { get => _Legajo; set => _Legajo = value; }
        public string DNI { get => _DNI; set => _DNI = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string Nacionalidad { get => _Nacionalidad; set => _Nacionalidad = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Localidad { get => _Localidad; set => _Localidad = value; }
        public string Provincia { get => _Provincia; set => _Provincia = value; }
        public string CorreoElectronico { get => _CorreoElectronico; set => _CorreoElectronico = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Especialidad { get => _Especialidad; set => _Especialidad = value; }
        public string DiasAtencion { get => _DiasAtencion; set => _DiasAtencion = value; }
        public string HorarioAtencion { get => _HorarioAtencion; set => _HorarioAtencion = value; }
    }
}
