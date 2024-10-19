using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioSucursal
    {
        DatosSucursales ds = new DatosSucursales();
        Sucursal sucursal = new Sucursal();
        public DataTable getTabla()
        {
            return ds.getTablaSucursal();
        }
        public DataTable getFiltrarSucursalID(int id)
        {
            return ds.FiltrarSucursalID(id);
        }

        public Sucursal getObtenerSucursal(int id)
        {
            sucursal.Id = id;
            return ds.getSucursal(sucursal);
        }

        public bool eliminarSucursal(int id)
        {
            sucursal.Id = id;
            int op = ds.eliminarSucursal(sucursal);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool agregarCategoria(String nombre)
        {
            int cantFilas = 0;

            sucursal.Nombre = nombre;

            if (ds.existeSucursal(sucursal) == false)
            {
                cantFilas = ds.agregarSucursal(sucursal);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }
    }
}
