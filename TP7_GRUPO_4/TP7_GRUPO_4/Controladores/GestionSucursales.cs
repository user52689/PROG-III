using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_4.Controladores
{
    public class GestionSucursales
    {
        private DataTable CrearDataTableSucursales()
        {
            DataTable sucursalesSeleccionadas = new DataTable();
            sucursalesSeleccionadas.Columns.Add("SucursalID", typeof(string));
            sucursalesSeleccionadas.Columns.Add("NombreSucursal", typeof(string));
            sucursalesSeleccionadas.Columns.Add("DescripcionSucursal", typeof(string));

            return sucursalesSeleccionadas;
        }

        public void VariableSessionSucursalesSeleccionadas(object sender, CommandEventArgs e, Label lblSucursalSeleccionada, Label lblCantidadSucursalesSeleccionadas)
        {
            if (e.CommandArgument == null) return;

            string sucursal = e.CommandArgument.ToString();

            // Recuperar el DataTable existente o crear uno nuevo
            DataTable sucursalesSeleccionadas = HttpContext.Current.Session["SucursalesSeleccionadas"] as DataTable;

            if (sucursalesSeleccionadas == null)
            {
                // Si no existe, crear uno nuevo
                sucursalesSeleccionadas = CrearDataTableSucursales();
            }

            // Verificar si la sucursal ya está seleccionada
            if (!sucursalesSeleccionadas.AsEnumerable().Any(row => row.Field<string>("NombreSucursal") == sucursal))
            {
                // Agregar la nueva sucursal
                DataRow dr = sucursalesSeleccionadas.NewRow();
                dr["SucursalID"] = sucursal; // Asigna el ID de sucursal adecuado aquí
                dr["NombreSucursal"] = sucursal; // Asigna el nombre de sucursal adecuado aquí
                dr["DescripcionSucursal"] = sucursal; // Asigna la descripción de sucursal adecuada aquí
                sucursalesSeleccionadas.Rows.Add(dr);

                // Actualizar la variable de sesión
                HttpContext.Current.Session["SucursalesSeleccionadas"] = sucursalesSeleccionadas;

                if (lblSucursalSeleccionada != null)
                {
                    lblSucursalSeleccionada.Text = "Sucursal seleccionada: " + sucursal;
                    lblCantidadSucursalesSeleccionadas.Text = "Total de sucursales seleccionadas: " + sucursalesSeleccionadas.Rows.Count;
                }
            }
            else
            {
                if (lblSucursalSeleccionada != null)
                {
                    lblSucursalSeleccionada.Text = "La sucursal ya ha sido seleccionada: " + sucursal;
                }
            }
        }

        public void CargarSucursalesEnGridView(GridView grdSucursales)
        {
            DataTable sucursalesSeleccionadas = HttpContext.Current.Session["SucursalesSeleccionadas"] as DataTable;

            if (sucursalesSeleccionadas != null && sucursalesSeleccionadas.Rows.Count > 0)
            {
                grdSucursales.DataSource = sucursalesSeleccionadas;
                grdSucursales.DataBind();
            }
        }
    }
}
