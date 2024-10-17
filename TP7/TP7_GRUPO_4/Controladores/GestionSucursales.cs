using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TP7_GRUPO_4.Conexion;

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

            string[] sucursal = e.CommandArgument.ToString().Split(',');
            string id = sucursal[0];
            string nombre = sucursal[1];
            string descp = sucursal[2];

            DataTable sucursalesSeleccionadas = HttpContext.Current.Session["SucursalesSeleccionadas"] as DataTable;

            if (sucursalesSeleccionadas == null)
            {
                sucursalesSeleccionadas = CrearDataTableSucursales();
            }

            if (!sucursalesSeleccionadas.AsEnumerable().Any(row => row.Field<string>("NombreSucursal") == nombre))
            {
                DataRow dr = sucursalesSeleccionadas.NewRow();
                dr["SucursalID"] = id;
                dr["NombreSucursal"] = nombre;
                dr["DescripcionSucursal"] = descp;
                sucursalesSeleccionadas.Rows.Add(dr);

                HttpContext.Current.Session["SucursalesSeleccionadas"] = sucursalesSeleccionadas;

                if (lblSucursalSeleccionada != null)
                {
                    lblSucursalSeleccionada.Text = "Sucursal seleccionada: " + sucursal[1];
                    lblCantidadSucursalesSeleccionadas.Text = "Total de sucursales seleccionadas: " + sucursalesSeleccionadas.Rows.Count;
                }
            }
            else
            {
                if (lblSucursalSeleccionada != null)
                {
                    lblSucursalSeleccionada.Text = "La sucursal ya ha sido seleccionada: " + sucursal[1];
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

        public DataTable BuscarSucursalPorNombre(string nombreSucursal)
        {
            AccesoDatos ad = new AccesoDatos();
            string consulta = "SELECT * FROM Sucursal";

            if (!string.IsNullOrEmpty(nombreSucursal))
            {
                consulta += " WHERE NombreSucursal LIKE @nombreSucursal";
            }

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, ad.EstablecerConexion());
            adaptador.SelectCommand.Parameters.AddWithValue("@nombreSucursal", "%" + nombreSucursal + "%");

            DataTable dtSucursales = new DataTable();
            adaptador.Fill(dtSucursales);

            return dtSucursales;
        }
    }
}
