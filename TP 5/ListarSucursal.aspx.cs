using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using static TP_5.Conexion;

namespace TP_5
{
    public partial class ListarSucursal : System.Web.UI.Page
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        Conexion conexion = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                FiltrarSucursalID(null);
            }
        }
        protected void FiltrarSucursalID(string idSucursal)
        {
            conexion = new Conexion();

            using (cn = new SqlConnection(conexion.getRuta()))
            {
                cn.Open();

                string consulta = @"SELECT S.Id_Sucursal, S.NombreSucursal AS Nombre, S.DescripcionSucursal AS Descripcion, P.DescripcionProvincia AS Provincia, S.DireccionSucursal As Direccion
                    FROM Sucursal S 
                    INNER JOIN Provincia P ON S.Id_ProvinciaSucursal = P.Id_Provincia";

                if (!string.IsNullOrEmpty(idSucursal))
                {
                    consulta += " WHERE Id_Sucursal = @Id_Sucursal";
                }

                using (cmd = new SqlCommand(consulta, cn))
                {
                    if (!string.IsNullOrEmpty(idSucursal))
                    {
                        cmd.Parameters.AddWithValue("@Id_Sucursal", idSucursal);
                    }
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            grdSucursales.DataSource = dr;
                            grdSucursales.DataBind();
                            lblMensaje.Text = string.Empty;
                        }
                        else
                        {
                            lblMensaje.Text = "No se encontraron sucursales con el ID proporcionado.";
                            grdSucursales.DataSource = null;
                            grdSucursales.DataBind();
                            txtIdSucursal.Text = string.Empty;
                        }
                    }
                }
            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            FiltrarSucursalID(null);
            LimpiarCampos();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string idSucursal = txtIdSucursal.Text.Trim();

            if (!string.IsNullOrEmpty(idSucursal))
            {
                FiltrarSucursalID(idSucursal);
            }
        }

        protected void LimpiarCampos()
        {
            txtIdSucursal.Text = string.Empty;
            lblMensaje.Text = string.Empty;
        }
    }
}