using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DropDownListService
    {
        private DatosDropDownList datosDropDownListService = new DatosDropDownList();

        //--------------------------------------------------------------------------------------------------------------------------------Para cargar ddls
        public List<Genero> ObtenerGeneros()
        {
            return datosDropDownListService.ObtenerGeneros();
        }

        public List<Pais> ObtenerPaises()
        {
            return datosDropDownListService.ObtenerPaises();
        }

        public List<Provincia> ObtenerProvincias()
        {
            return datosDropDownListService.ObtenerProvincias();
        }
        public List<Localidad> ObtenerLocalidadesPorProvincia(int idProvincia)
        {
            return datosDropDownListService.ObtenerLocalidadesPorProvincia(idProvincia);
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            return datosDropDownListService.ObtenerEspecialidades();
        }

        //---------------------------------------------------------------------------------------------------------Para cargar ddls con datos de registros en modo edicion FALTA PARA LA EDICION - NO BORRAR!

        //public DataTable ObtenerGenerosEdicion()
        //{
        //    return datosDropDownListService.ObtenerGenerosEdicion();
        //}

        //public List<Pais> ObtenerPaisesEdicion()
        //{
        //    return datosDropDownListService.ObtenerPaisesEdicion();
        //}

        //public List<Provincia> ObtenerProvinciasEdicion()
        //{
        //    return datosDropDownListService.ObtenerProvinciasEdicion();
        //}
        //public List<Localidad> ObtenerLocalidadesPorProvinciaEdicion(int idProvincia)
        //{
        //    return datosDropDownListService.ObtenerLocalidadesPorProvinciaEdicion(idProvincia);
        //}

        //public List<Especialidad> ObtenerEspecialidadesEdicion()
        //{
        //    return datosDropDownListService.ObtenerEspecialidadesEdicion();
        //}

    }
}
