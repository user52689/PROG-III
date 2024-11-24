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
        readonly Medico medico = new Medico();
        readonly DatosMedico datosM = new DatosMedico();

        //--------------------------------------------------------------------------------------------------------------------------------ALTA
        public bool AgregarMedico(Medico medico)
        {

            return datosM.Agregar_Med(medico);

        }
        //---------------------------------------------------------------------------------------------------------------------------------BAJA
        public int EliminarMedicoNegocio(int Legajo) //
        {
            medico.Legajo = Legajo;

            int eliminado = datosM.EliminarMedicosDatos(medico);

            if (eliminado >= 1)
            {
                return eliminado;
            }
            else
            {
                return eliminado;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------MODIFICACION
        public DataTable ModificarMedicoNegocio(Medico medico)
        {
            return datosM.ModificarMedicoDatos(medico);
        }



        //-------------------------------------------------------------------------------------------------------------------------------LISTADO
        public DataTable GetTablaMedicosNegocios() //Muestra todos los medicos con todos los campos
        {
            return datosM.GetTablaMedicosDatos();
        }
        public DataTable FiltrarMedicoLegajoNegocios(int Legajo) //Muestra y filtra un medico con los campos seleccionados 
        {
            return datosM.FiltrarMedicoLegajoBajaDatos(Legajo);
        }
        public DataTable FiltrarMedicosPorLegajoNegocio(int legajo) //Muestra y filtra un medico por DNI con todos los campos
        {
            return datosM.FiltrarMedicoLegajoDatos(legajo);
        }


        //-------------------------------------------------------------------------------------------------------------------------------Metodos
        public int ObtenerMaximoLegajoNegocio()
        {
           return datosM.ObtenerMaximoLegajoDatos();
        }
    }
}
