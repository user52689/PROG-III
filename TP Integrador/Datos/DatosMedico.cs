using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosMedico
    {
        readonly AccesoDatos ad = new AccesoDatos();


        //------------------------------------------------------------------------------------Obtener medicos
        public DataTable GetTablaMedicosDatos() //Todos los medicos
        {
            string consulta = "SELECT * " +
                              "FROM Medicos";
            return ad.ObtenerTabla("Medicos", consulta);
        }
        public DataTable FiltrarMedicoLegajoDatos(int Legajo) //Medico filtrado para la baja de paciente
        {
            string consulta = "SELECT Legajo_med, DNI_med Nombre_med, Apellido_med " +
                              "FROM Medicos " +
                              "WHERE Legajo_med = @Legajo";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@Legajo", Legajo);
            return ad.ObtenerTablaConComando("Medicos", cmd);
        }

        //--------------------------------------------------------------------------------------Eliminar Medicos

        public int EliminarMedicosDatos(Medico medico)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_EliminarMedico";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Legajo_med", medico.Legajo);

            return ad.EjecutarProcedimientoAlmacenado(cmd, "SP_EliminarMedico");
        }
    }
}
