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
        private readonly AccesoDatos accesoDatos = new AccesoDatos();
        readonly Paciente paciente = new Paciente();
        readonly DatosPaciente datosP = new DatosPaciente();
        DataTable dt = new DataTable();

    
        public List<Paciente> ObtenerTodosLosPacientes()
    {
       return datosP.ObtenerListaPacientes();
    }


    public List<Paciente> ObtenerPacientesPorDNI(string dni)
    {
        return datosP.FiltrarPacientesPorDNI(dni);
    }


    public bool agregarPaciente(Paciente NuevoPaciente)
    {
    
        return datosP.AgregarPaciente(NuevoPaciente);

    }


    public bool ExistePaciente(string dni)
    {

        return datosP.ExistePaciente(dni);

    }

        //-----------------------------------------------------------------------------------------------------------------------------Obtener todos los pacientes, y paciente filtrado por dni
        public DataTable GetTablaPacienteNegocios()
        {
            return datosP.GetTablaPacientesDatos();
        }


    
        //--------------------------------------------------------------------------------------Baja Paciente

        public DataTable FiltrarPacienteDNIBajaNegocios(string DNI)  //Muestra los campos seleccionados para la Baja
        {
            return datosP.FiltrarPacienteDNIBajaDatos(DNI);
        }
        public DataTable FiltrarPacienteDNIModificacionNegocios(string DNI)     //Muestra los campos seleccionados para la Modificacion
        {
            return datosP.FiltrarPacienteDNIModificacionDatos(DNI);
        }

        public int EliminarPacienteNegocio(string DNI)
        {
            paciente.DNI = DNI;

            int estado = 0;

            estado = datosP.EliminarPacienteDatos(paciente);

            return estado;
        }
        
        //---------------------------------------------------------------------------------------Cargas de los ddl 

        //------------------------------------------------Carga de Generos
        public DataTable CargarGenerosNegocio()
        {            
            return dt = datosP.ObtenerGeneros();
        }
        //------------------------------------------------Carga de Nacionalidades
        public DataTable CargarNacionalidadesNegocio()
        {
            return dt = datosP.ObtenerNacionalidades();
        }
        //------------------------------------------------Carga de Provincias
        public DataTable CargarProvinciasNegocio()
        {
            return dt = datosP.ObtenerProvincias();         
        }

        //------------------------------------------------Carga de Localidades
        public DataTable CargarLocalidadesNegocio()
        {
            return dt = datosP.ObtenerLocalidades();
        }
        public DataTable CargarLocalidadesPorProvinciaNegocio(int IdProvincia)
        {
            return dt = datosP.ObtenerLocalidadesPorProvincia(IdProvincia);
        }

        //------------------------------------------------------------------------Actualizar paciente
        public DataTable ModificarPacienteNegocio(Paciente paciente)
        {
            return dt = datosP.ModificarPacienteDatos(paciente);
        }
    }
}
