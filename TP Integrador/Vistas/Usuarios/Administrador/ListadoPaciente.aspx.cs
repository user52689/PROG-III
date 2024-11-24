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


        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }
        void mostrarTodos()
        {
            DataTable dt = negociosPaciente.GetTablaPacienteNegocios();
            CargarGridPacientes(dt);
        }
        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            mostrarTodos();
        }

        //-------------------------------------------------------------------------------------------------------------Metodos

        void CargarGridPacientes(DataTable dt)
        {
            grdListadoPaciente.DataSource = dt;
            grdListadoPaciente.DataBind();
        }

    }
}

