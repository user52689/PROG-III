using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO_4.Controladores;
using TP6_GRUPO_4.Entidades;

namespace TP6_GRUPO_4
{
    public partial class Ejercicio1 : System.Web.UI.Page
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
            grdProductos.DataSource = gp.ObtenerTodosLosProductos();
            grdProductos.DataBind();
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            CargarProductos();
        }

        protected void grdProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdProducto = ((Label)grdProductos.Rows[e.RowIndex].FindControl("lblIdProducto")).Text;
            Producto prd = new Producto
            {
                IdProducto = Convert.ToInt32(IdProducto)
            };

            GestionProductos gp = new GestionProductos();
            gp.EliminarProducto(prd);

            CargarProductos();
        }

        protected void grdProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProductos.EditIndex = e.NewEditIndex;
            CargarProductos();
        }

        protected void grdProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProductos.EditIndex = -1;
            CargarProductos();
        }

        protected void grdProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string IdProducto = ((Label)grdProductos.Rows[e.RowIndex].FindControl("lbl_idProducto")).Text;
            string NombreProducto = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txt_edit_nombreProducto")).Text;
            string CantidadPorUnidad = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txt_edit_CantidadPorUnidad")).Text;
            string PrecioUnidad = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txt_edit_precioUnidad")).Text;

            Producto prd = new Producto();
            prd.IdProducto = Convert.ToInt32(IdProducto);
            prd.NombreProducto = NombreProducto;
            prd.CantidadPorUnidad = CantidadPorUnidad;
            prd.PrecioUnidad = Convert.ToDecimal(PrecioUnidad);


            GestionProductos gp = new GestionProductos();
            gp.ActualizarProductos(prd);

            grdProductos.EditIndex = -1;
            CargarProductos();
        }
    }
}