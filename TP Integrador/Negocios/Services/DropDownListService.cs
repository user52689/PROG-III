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

        //-------------------------------------------------------------------------------------------------------------------------------------ALTA
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
    }
}
