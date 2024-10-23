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

        public bool agregarSucursal(Sucursal sucursal)
        {
            if (!ds.existeSucursal(sucursal))
            {
                int filasAfectadas = ds.agregarSucursal(sucursal);
                return filasAfectadas > 0;
            }
            else
            {
                return false; // La sucursal ya existe
            }
        }

        public bool ExisteSucursalPorID(int id)
        {
            DataTable dt = ds.FiltrarSucursalID(id);
            return dt.Rows.Count > 0;
        }
    }

}
