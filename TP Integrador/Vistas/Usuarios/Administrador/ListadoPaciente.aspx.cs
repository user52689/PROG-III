using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        readonly NegociosPaciente negocioPaciente = new NegociosPaciente();
        public void Cargargrv()
        {
            NegociosPaciente ngp = new NegociosPaciente();
            grvPacientes.DataSource = ngp.ObtenerListaPacientes();
            grvPacientes.DataBind();       

        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            grvPacientes.Visible = true;
            Cargargrv();
        }

        protected void btnDni_Click(object sender, EventArgs e)
        {
            NegociosPaciente negocio = new NegociosPaciente();
            string dni = txtBuscarPorDNI.Text;


            Paciente paciente = negocio.FiltrarPacientePorDni(dni);

            if (paciente != null)
            {
                grvPacientes.Visible = true;
                grvPacientes.DataSource = new List<Paciente> { paciente };
                grvPacientes.DataBind();
            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Paciente no encontrado');", true);
            }
            txtBuscarPorDNI.Text = "";
        }
    }
}