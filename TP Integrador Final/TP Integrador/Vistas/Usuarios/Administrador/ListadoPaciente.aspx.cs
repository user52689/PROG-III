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
    public partial class ListadoPaciente : System.Web.UI.Page
    {
        private NegociosPaciente negociosPaciente = new NegociosPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarAcceso();
        }

        //---------------------------------------------------------------------------------------------------------------Eventos
        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            DataTable dt = negociosPaciente.FiltrarPacienteDNINegocios(txtBuscarPorDNI.Text);

            if (dt != null)
            {
                CargarGridPacientes(dt);
                lblMensajePaciente.Text = string.Empty;
            }
            else
            {
                CargarGridPacientes(dt);
                txtBuscarPorDNI.Text = string.Empty;
                lblMensajePaciente.Text = "No se encontró el paciente.";
                lblMensajePaciente.ForeColor = System.Drawing.Color.Red;
            }

        }

        void mostrarTodos()
        {
            lblMensajePaciente.Text = string.Empty;
            grdListadoPaciente.AllowPaging = true;
            DataTable dt = negociosPaciente.GetTablaPacienteNegocios();
            CargarGridPacientes(dt);
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            lblMensajePaciente.Text = string.Empty;
            mostrarTodos();
        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            grdListadoPaciente.DataSource = null;
            grdListadoPaciente.DataBind();
            txtBuscarPorDNI.Text = string.Empty;
        }

        //-------------------------------------------------------------------------------------------------------------Metodos

        void CargarGridPacientes(DataTable dt)
        {
            grdListadoPaciente.DataSource = dt;
            grdListadoPaciente.DataBind();
        }
        protected void VerificarAcceso()
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] as Usuario;

            if (usuarioLogueado == null || !usuarioLogueado.EsAdministrador())
            {
                Response.Redirect("~/Inicio/AccesoDenegado.aspx");
                return;
            }

            // Mostrar el nombre de usuario en la barra de navegacion
            lblUsuarioEnSesion.Text = usuarioLogueado.NombreUsuario;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Inicio/InicioSesion.aspx");
        }

        protected void grdListadoPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdListadoPaciente.PageIndex = e.NewPageIndex;
            mostrarTodos(); // Vuelve a cargar los datos - para mantener la paginacion.
        }
    }
}

