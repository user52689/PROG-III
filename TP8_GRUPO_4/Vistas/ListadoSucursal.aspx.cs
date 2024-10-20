using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoSucursal : System.Web.UI.Page
    {
        NegocioSucursal ns = new NegocioSucursal();
        Sucursal sc = new Sucursal();
        DataTable dt = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridSucursales();
            }
        }

        protected void btnFiltrarSucursal_Click(object sender, EventArgs e)
        {
            dt = ns.getFiltrarSucursalID(int.Parse(txtBusquedaSucursalID.Text));
            grdSucursales.DataSource = dt;
            grdSucursales.DataBind();
        }

        protected void CargarGridSucursales()
        {
            dt = ns.getTabla();
            grdSucursales.DataSource = dt;
            grdSucursales.DataBind();
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            CargarGridSucursales();
            LimpiarCampos();

        }

        protected void LimpiarCampos()
        {
            txtBusquedaSucursalID.Text = string.Empty;
            
        }
    }
}