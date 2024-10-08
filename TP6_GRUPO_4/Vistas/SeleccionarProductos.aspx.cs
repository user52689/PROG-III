using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO_4.Controladores;

namespace TP6_GRUPO_4.Vistas
{
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarProductos();
            }
        }
        private void CargarProductos()
        {
            GestionProductos gp = new GestionProductos();
            grdProductoSeleccionado.DataSource = gp.ObtenerTodosLosProductos();
            grdProductoSeleccionado.DataBind();
        }

        protected void grdProductoSeleccionado_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string IdProducto = ((Label)grdProductoSeleccionado.Rows[e.NewSelectedIndex].FindControl("lbl_it_IDProducto")).Text;
            string NombreProducto = ((Label)grdProductoSeleccionado.Rows[e.NewSelectedIndex].FindControl("lbl_it_NombreProducto")).Text;
            string CantidadPorUnidad = ((Label)grdProductoSeleccionado.Rows[e.NewSelectedIndex].FindControl("lbl_it_CantidadPorUnidad")).Text;
            string PrecioUnidad = ((Label)grdProductoSeleccionado.Rows[e.NewSelectedIndex].FindControl("lbl_it_PrecioUnidad")).Text;

            DataTable dt;
            if (Session["ProductosSeleccionados"] == null)
            {
                dt = new DataTable();
                dt.Columns.Add("IdProducto", typeof(string));
                dt.Columns.Add("NombreProducto", typeof(string));
                dt.Columns.Add("CantidadPorUnidad", typeof(string));
                dt.Columns.Add("PrecioUnidad", typeof(string));

                Session["ProductosSeleccionados"] = dt;
            }
            else
            {
                dt = (DataTable)Session["ProductosSeleccionados"];
            }

            // Verificacion para evitar duplicados
            bool productoYaSeleccionado = false;
            foreach (DataRow row in dt.Rows)
            {
                if (row["IdProducto"].ToString() == IdProducto)
                {
                    productoYaSeleccionado = true;
                    break;
                }
            }

            if (!productoYaSeleccionado)
            {
                DataRow dr = dt.NewRow();
                dr["IdProducto"] = IdProducto;
                dr["NombreProducto"] = NombreProducto;
                dr["CantidadPorUnidad"] = CantidadPorUnidad;
                dr["PrecioUnidad"] = PrecioUnidad;
                dt.Rows.Add(dr);


                lblMensaje.Text = "Producto/s seleccionado/s :";

                lblProductosAgregados.Text += NombreProducto + ", ";
                Session["ProductosSeleccionados"] = dt;


            }
            else
            {
                lblMensaje.Text = "El producto " + NombreProducto + " ya fue seleccionado.";
            }
        

        }

        protected void grdProductoSeleccionado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductoSeleccionado.PageIndex = e.NewPageIndex;

            CargarProductos();
        }
    }
}