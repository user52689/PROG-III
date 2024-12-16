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
    public partial class BajaPaciente : System.Web.UI.Page
    {
        NegociosPaciente negocioP = new NegociosPaciente();
        Paciente paciente = new Paciente();
        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarAcceso();
        }

        protected void grdPacientesBaja_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string DNI = ((Label)grdPacientesBaja.Rows[e.RowIndex].FindControl("lbl_it_DNIPaciente")).Text;

            int eliminado = negocioP.EliminarPacienteNegocio(DNI);


            if (eliminado >= 1)
            {
                txtBuscarPorDNI.Text = string.Empty;
                lblMensaje.Text = "Paciente eliminado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                txtBuscarPorDNI.Text = string.Empty;
                lblMensaje.Text = "No se pudo eliminar el paciente";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            dt = negocioP.FiltrarPacienteDNIBajaNegocios(txtBuscarPorDNI.Text);

            if (dt.Rows.Count > 0)
            {
                grdPacientesBaja.DataSource = dt;
                grdPacientesBaja.DataBind();
                lblMensaje.Text = string.Empty;
            }
            else
            {
                grdPacientesBaja.DataSource = null;
                grdPacientesBaja.DataBind();
                lblMensaje.Text = "No se encontró el paciente.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            grdPacientesBaja.DataSource = null;
            grdPacientesBaja.DataBind();
            txtBuscarPorDNI.Text = string.Empty;
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