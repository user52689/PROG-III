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
    public partial class ListadoMedico : System.Web.UI.Page
    {
        readonly NegociosMedico negociosMedico = new NegociosMedico();

        protected void Page_Load(object sender, EventArgs e)
        {
           VerificarAcceso();
        }

        //----------------------------------------------------------------------------------------------------------Eventos


        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            MostrarTodos();
        }

        protected void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            DataTable dt = negociosMedico.FiltrarMedicosPorLegajoNegocio(Convert.ToInt32(txtBuscarPorLegajo.Text));

            if (dt != null)
            {
                CargarGridMedicos(dt);
                lblMensajeMedico.Text = string.Empty;
            }
            else
            {
                CargarGridMedicos(dt);
                txtBuscarPorLegajo.Text = string.Empty;
                lblMensajeMedico.Text = "No se encontró el medico.";
                lblMensajeMedico.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            grdListadoMedico.DataSource = null;
            grdListadoMedico.DataBind();
            txtBuscarPorLegajo.Text = string.Empty;
        }

        //----------------------------------------------------------------------------------------------------------Metodos
        void MostrarTodos()
        {
            lblMensajeMedico.Text = string.Empty;
            grdListadoMedico.AllowPaging = true;
            DataTable dt = negociosMedico.GetTablaMedicosNegocios();
            CargarGridMedicos(dt);
        }


        void CargarGridMedicos(DataTable dt)
        {
            grdListadoMedico.DataSource = dt;
            grdListadoMedico.DataBind();
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

        protected void grdListadoMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdListadoMedico.PageIndex = e.NewPageIndex;
            MostrarTodos(); // Vuelve a cargar los datos - para mantener la paginacion.
        }
    }
}

