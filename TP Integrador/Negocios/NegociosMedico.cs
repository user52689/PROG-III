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
        public Medico ObtenerMedicosPorLegajo(int Legajo)
        {
            DataTable dt = accesoDatos.FiltrarMedicoPorLegajo(Legajo);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Medico
                {
                    Legajo = Convert.ToInt32(row["Legajo_med"]),
                    DNI = row["DNI_med"].ToString(),
                    Nombre = row["Nombre_med"].ToString(),
                    Apellido = row["Apellido_med"].ToString(),
                    Genero = Convert.ToInt32(row["Genero_med"]),
                    Nacionalidad = Convert.ToInt32(row["Nacionalidad_med"]),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento_med"]),
                    Direccion = row["Direccion_med"].ToString(),
                    Localidad = Convert.ToInt32(row["Localidad_med"]),
                    Provincia = Convert.ToInt32(row["Provincia_med"]),
                    CorreoElectronico = row["CorreoElectronico_med"].ToString(),
                    Telefono = row["Telefono_med"].ToString(),
                    Especialidad = Convert.ToInt32(row["Especialidad_med"])
                };
            }
            return null;
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
