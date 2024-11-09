using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class ListadoPaciente : System.Web.UI.Page
    {


        private NegociosPaciente negocioPaciente = new NegociosPaciente();
        public void cargargrv()
        {
            NegociosPaciente ngp = new NegociosPaciente();
            grvPacientes.DataSource = ngp.ObtenerListaPacientes(); 
            grvPacientes.DataBind();
            
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            grvPacientes.Visible = true;
            cargargrv();
        }

        protected void btnDni_Click(object sender, EventArgs e)
        {
            NegociosPaciente negocio = new NegociosPaciente();
            string dni = txtBuscarPorDNI.Text;
            

            Paciente paciente = negocio.ObtenerPacientePorDNI(dni);

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


          




    

    
 
