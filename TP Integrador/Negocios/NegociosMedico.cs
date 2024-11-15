using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace Negocios
{
    public class NegociosMedico
    {
        private readonly AccesoDatos accesoDatos = new AccesoDatos();
        readonly Medico medico = new Medico();
        readonly DatosMedico datosM = new DatosMedico();
        DataTable dt = new DataTable();

        public DataTable GetTablaMedicosNegocios() //
        {
            return datosM.GetTablaMedicosDatos();
        }





        public DataTable FiltrarMedicoLegajoNegocios(int Legajo) //
        {
            return datosM.FiltrarMedicoLegajoDatos(Legajo);
        }


        public int EliminarMedicoNegocio(int Legajo) //
        {
            medico.Legajo = Legajo;
            int estado = datosM.EliminarMedicosDatos(medico);
            if (estado >= 1)
            {
                return estado;
            }
            else
            {
                return estado;
            }
        }

        //---------------------------------------------------------------------------------------
         public List<Medico> obtenerListaMedicos()
   {
            return datosM.ObtenerListaMedicos();
   }


   public List<Medico> ObtenerMedicosPorLegajo(int legajo)
   {
       return datosM.FiltrarMedicosPorLegajo(legajo);
   }

        public DataTable ModificarMedicoNegocio(Medico medico)
        {
            return dt = datosM.ModificarMedicoDatos(medico);
        }

        //------------------------------------------------Carga de Generos
        public DataTable CargarGenerosNegocio()
        {
            return dt = datosM.ObtenerGeneros();
        }

        //------------------------------------------------Carga de Nacionalidades
        public DataTable CargarNacionalidadesNegocio()
        {
            return dt = datosM.ObtenerNacionalidades();
        }

        //------------------------------------------------Carga de Provincias
        public DataTable CargarProvinciasNegocio()
        {
            return dt = datosM.ObtenerProvincias();
        }

        //------------------------------------------------Carga de Localidades
        public DataTable CargarLocalidadesNegocio()
        {
            return dt = datosM.ObtenerLocalidades();
        }

        public DataTable CargarLocalidadesPorProvinciaNegocio(int IdProvincia)
        {
            return dt = datosM.ObtenerLocalidadesPorProvincia(IdProvincia);
        }
        //-------------------------------------------------Carga de Especialidades
        public DataTable CargarEspecialidadesNegocio() {

            return dt = datosM.obtenerEspecialidades();
        }


    }
}
