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
            int sucursalID;
            lblMensaje.Text = ""; // Limpiar el mensaje

            // Validar si el ID ingresado es un número
            if (int.TryParse(txtBusquedaSucursalID.Text, out sucursalID))
            {
                // Verificar si la sucursal existe por el ID
                if (ns.ExisteSucursalPorID(sucursalID))
                {
                    // Si la sucursal existe, cargar los datos filtrados
                    dt = ns.getFiltrarSucursalID(sucursalID);
                    grdSucursales.DataSource = dt;
                    grdSucursales.DataBind();
                }
                else
                {
                    // Si no existe, mostrar un mensaje de error
                    lblMensaje.Text = "El ID de sucursal no existe en la base de datos.";
                    LimpiarCampos();
                }
            }
            else
            {
                // Si el ID no es válido, mostrar un mensaje de error
                lblMensaje.Text = "Por favor, ingrese un ID válido.";
                LimpiarCampos();
            }
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
            lblMensaje.Text = ""; // Limpiar el mensaje

        }

        protected void LimpiarCampos()
        {
            txtBusquedaSucursalID.Text = string.Empty;

        }
    }
}