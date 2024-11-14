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
        private NegociosPaciente negociosPaciente = new NegociosPaciente();

     

        void mostrarTodos()
        {
            var listaPacientes = negociosPaciente.ObtenerTodosLosPacientes();
           grdListadoPaciente.DataSource = listaPacientes;
            grdListadoPaciente.DataBind();
        }

        void mostrarDniPaciente()
        {
            string dni = txtBuscarPorDNI.Text;
            var listaPacientes = negociosPaciente.ObtenerPacientesPorDNI(dni);
            grdListadoPaciente.DataSource = listaPacientes;
            grdListadoPaciente.DataBind();
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            mostrarDniPaciente();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            mostrarTodos();
        }
    }

}
