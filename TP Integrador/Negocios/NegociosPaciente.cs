using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocios
{
    public class NegociosPaciente
    {
        private DatosPaciente datosPaciente = new DatosPaciente();

   
        public Paciente ObtenerPacientePorDni(int dni)
        {
            if (dni <= 0)
            {
                throw new ArgumentException("El DNI debe ser un número válido.");
            }

            return datosPaciente.ObtenerPacientes(dni); 
        }

        public bool AgregarPaciente(Paciente nuevoPaciente)
        {
            if (nuevoPaciente == null)
                throw new ArgumentNullException("El objeto paciente no puede ser nulo.");

            return datosPaciente.AgregarPaciente(nuevoPaciente);
        }

       
    }
}
