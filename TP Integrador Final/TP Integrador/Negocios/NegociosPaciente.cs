using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;


namespace Negocios
{
    public class NegociosPaciente
    {
        readonly Paciente paciente = new Paciente();
        readonly DatosPaciente datosP = new DatosPaciente();


        //--------------------------------------------------------------------------------------------------------------------------------ALTA

        public bool AgregarPaciente(Paciente NuevoPaciente)
        {
    
            return datosP.AgregarPaciente(NuevoPaciente);

        }

        //-------------------------------------------------------------------------------------------------------------------------------BAJA
        public int EliminarPacienteNegocio(string DNI)
        {
            paciente.DNI = DNI;

            int eliminado = datosP.EliminarPacienteDatos(paciente);

            if (eliminado >= 1)
            {
                return eliminado;
            }
            else
            {
                return eliminado;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------MODIFICACION
        public int ModificarPacienteNegocio(Paciente paciente)
        {
            return datosP.ModificarPacienteDatos(paciente);
        }
 
        
        //--------------------------------------------------------------------------------------------------------------------------------LISTADO
        public DataTable GetTablaPacienteNegocios()//Muestra todos los pacientes con todos los campos
        {
            return datosP.GetTablaPacientesDatos();
        }
        public DataTable FiltrarPacienteDNIBajaNegocios(string DNI)//Muestra un paciente y filtra los campos seleccionados
        {
            return datosP.FiltrarPacienteDNIBajaDatos(DNI);
        }
        public DataTable FiltrarPacienteDNINegocios(string DNI)//Muestra un paciente y filtra todos los campos
        {
            return datosP.FiltrarPacienteDNIDatos(DNI);
        }        
    }
}
