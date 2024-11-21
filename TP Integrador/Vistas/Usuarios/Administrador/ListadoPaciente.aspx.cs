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

           
            lblMensajePaciente.Visible = false;
            grdListadoPaciente.Visible = true; 
        }

        void mostrarDniPaciente()
        {
            string dni = txtBuscarPorDNI.Text.Trim();

            
            if (string.IsNullOrEmpty(dni))
            {
                lblMensajePaciente.Text = "Por favor, ingrese un DNI.";
                lblMensajePaciente.ForeColor = System.Drawing.Color.Red;
                lblMensajePaciente.Visible = true; 
                grdListadoPaciente.Visible = false; 
                return;
            }

            
            if (dni.Length > 11)
            {
                lblMensajePaciente.Text = "DNI NO VALIDO.";
                lblMensajePaciente.ForeColor = System.Drawing.Color.Red;
                lblMensajePaciente.Visible = true; 
                grdListadoPaciente.Visible = false; 
                return;
            }

            var listaPacientes = negociosPaciente.ObtenerPacientesPorDNI(dni);
            grdListadoPaciente.DataSource = listaPacientes;
            grdListadoPaciente.DataBind();

           
            if (listaPacientes.Count == 0)
            {
                lblMensajePaciente.Text = "No se encontró un paciente con el DNI especificado.";
                lblMensajePaciente.ForeColor = System.Drawing.Color.Red;
                lblMensajePaciente.Visible = true; 
                grdListadoPaciente.Visible = false;
            }
            else
            {
                lblMensajePaciente.Visible = false;  
                grdListadoPaciente.Visible = true; 
            }
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            mostrarDniPaciente();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            mostrarTodos();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("InicioSesion.aspx");
        }
    }
}

