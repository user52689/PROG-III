using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class BajaMedico : System.Web.UI.Page
    {
        NegociosMedico negocioM = new NegociosMedico();
        DataTable dt = new DataTable();
        Medico medico = new Medico();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarAcceso();
        }


        protected void grdMedicosBaja_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Legajo = Convert.ToInt32(((Label)grdMedicosBaja.Rows[e.RowIndex].FindControl("lbl_it_LegajoMedico")).Text);

            int eliminado = negocioM.EliminarMedicoNegocio(Legajo);


            if (eliminado >= 1)
            {
                txtBuscarPorLegajo.Text = string.Empty;
                lblMensaje.Text = "Medico eliminado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                txtBuscarPorLegajo.Text = string.Empty;
                lblMensaje.Text = "No se pudo eliminar el medico";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dt = negocioM.FiltrarMedicoLegajoNegocios(Convert.ToInt32(txtBuscarPorLegajo.Text));

            if (dt.Rows.Count > 0)
            {
                grdMedicosBaja.DataSource = dt;
                grdMedicosBaja.DataBind();
                lblMensaje.Text = string.Empty;
            }
            else
            {
                grdMedicosBaja.DataSource = null;
                grdMedicosBaja.DataBind();
                lblMensaje.Text = "No se encontró el medico.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            grdMedicosBaja.DataSource = null;
            grdMedicosBaja.DataBind();
            txtBuscarPorLegajo.Text = string.Empty;
            lblMensaje.Text = string.Empty;
        }

        //---------------------------------------------------------------------------------------------Metodos
        protected void VerificarAcceso()
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] as Usuario;

            if (usuarioLogueado == null || !usuarioLogueado.EsAdministrador())
            {
                Response.Redirect("~/Inicio/AccesoDenegado.aspx");
                return;
            }

            // Mostrar el nombre de usuario en la barra de navegación
            lblUsuarioEnSesion.Text = usuarioLogueado.NombreUsuario;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Inicio/InicioSesion.aspx");
        }
    }
}