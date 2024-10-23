using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        NegocioSucursal negocioSucursal = new NegocioSucursal();
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        NegocioProvincia np = new NegocioProvincia();

        private void CargarProvincias(DropDownList ddlProvincias)
        {
            ddlProvincias.DataSource =np.CargarProvincias();
            ddlProvincias.DataTextField = "DescripcionProvincia"; 
            ddlProvincias.DataValueField = "Id_Provincia"; 
            ddlProvincias.DataBind();
            ddlProvincias.Items.Insert(0, new ListItem("--Seleccione--", "0")); 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarProvincias(ddlProvincias);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Sucursal sucursal = new Sucursal
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    IdProvincia = Convert.ToInt32(ddlProvincias.SelectedValue),
                    Direccion = txtDireccion.Text
                };

                bool agregado = negocioSucursal.agregarSucursal(sucursal);

                if (agregado)
                {
                    lblMensaje.Text = "Se agregó la sucursal correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Error: la sucursal ya existe o ocurrió un problema.";
                }

                limpiarCampos();
            }

        }

        protected void limpiarCampos()
        {
            txtDescripcion.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            ddlProvincias.SelectedIndex = 0;
        }
    }

}